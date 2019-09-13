using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Shared.ProductService.Dto
{
    public class ProductDto:BaseEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
    }
}
