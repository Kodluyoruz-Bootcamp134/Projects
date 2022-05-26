using AutoMapper;
using Bookstore.DataTransferObjects.Requests;
using Bookstore.DataTransferObjects.Responses;
using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Business.Mapping
{
    public class MapProfile : Profile
    {

        public MapProfile() 
        {
            CreateMap<Book, BookDisplayResponse>();
            CreateMap<AddBookRequest, Book>();
        }
    }
}
