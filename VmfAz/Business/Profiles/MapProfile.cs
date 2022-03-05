using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap();
            
        }
    }
}
