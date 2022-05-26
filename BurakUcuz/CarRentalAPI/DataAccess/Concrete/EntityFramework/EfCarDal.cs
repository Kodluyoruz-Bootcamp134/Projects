using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentDbContext context = new RentDbContext())
            {
                var result = from car in context.Cars
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             join br in context.Brands
                             on car.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 CarName = car.CarName,
                                 Description = car.Description,
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
