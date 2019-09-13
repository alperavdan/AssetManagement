using AssetManagement.Service.Shared.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Shared.ProductService
{
    public interface IProductService
    {
        ProductDto GetProduct(long id);

        IEnumerable<ProductDto> GetProducts();

        void CreateProduct(ProductDto product);

        void UpdateProduct(ProductDto product);

        void DeleteProduct(long id);

        void SaveCategory();
    }
}
