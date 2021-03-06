using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.OrderDTOs;
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
            CreateMap<BasketItem, BasketItemAddDto>().ReverseMap();
            CreateMap<Order, OrderAddDto>().ReverseMap();
            CreateMap<ShopPostDto, Shop>().ReverseMap();
            CreateMap<OrderGetDto, Order>();
            CreateMap<ProductGetDto, Product>();

        }
    }
}
