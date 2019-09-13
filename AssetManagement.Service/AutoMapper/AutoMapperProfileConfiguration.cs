using AssetManagement.Model;
using AssetManagement.Service.Shared.CategoryService.Dto;
using AssetManagement.Service.Shared.ProductService.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.AutoMapper
{
   public class AutoMapperProfileConfiguration:Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Model.Category>().ReverseMap();
        }
    }
}
