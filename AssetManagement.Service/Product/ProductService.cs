using AssetManagement.Data.Infrastructure;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Service.Shared.ProductService;
using AssetManagement.Service.Shared.ProductService.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagement.Service.Product
{
    public class ProductService : IProductService
    {


        private readonly IProductRepository _productRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public void CreateProduct(ProductDto product)
        {
            _productRepository.Add(_mapper.Map<ProductDto, Model.Product>(product));
            _unitOfWork.Commit();
        }

        public void DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(long id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProductByName(string productName)
        {
           return _mapper.Map<ProductDto>(_productRepository.GetAll().FirstOrDefault(x => x.Title == productName));
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
