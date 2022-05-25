using AutoMapper;
using BookCategory.DataTransferObjects.Requests;
using BookCategory.DataTransferObjects.Responses;
using BookCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDisplayResponse>();
            CreateMap<AddBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();
        }
    }
}
