using AssetManagement.Data.Infrastructure;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AssetManagement.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private DbContext _dbContext;
        private IUnitOfWork _uow;

        public ProductRepository(ApplicationDbContext dbContext,IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

      
        public void Add(Product entity)
        {
            _dbContext.Set<Product>().Add(entity);
            _uow.Commit();
            
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> where, params string[] navigations)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(params string[] navigations)
        {
            throw new NotImplementedException();
        }

        public Product GetById(long id, params string[] navigations)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where, params string[] navigations)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string productName)
        {
            var product= _dbContext.Set<Product>().FirstOrDefault(x => x.Title == productName);
           
            return product;
        }
    }
}
