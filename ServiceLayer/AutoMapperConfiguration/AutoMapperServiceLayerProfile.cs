using AutoMapper;
using Entities.Entities;
using ServiceLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapperConfiguration
{
    public class AutoMapperServiceLayerProfile:Profile
    {
        public AutoMapperServiceLayerProfile()
        {
            CreateMap<Product, InsertProductDto>();
            CreateMap<InsertProductDto, Product>();
            CreateMap<GetAllProductDto, Product>();
            CreateMap<Product, GetAllProductDto>();
            CreateMap<RemoveProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
