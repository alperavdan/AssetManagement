using AssetManagement.Service.Shared.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Shared.CategoryService.Dto
{
   public class CategoryDto:BaseEntityDto
    {
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new HashSet<ProductDto>();
    }
}
