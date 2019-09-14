using AssetManagement.Data.Infrastructure;
using AssetManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Repositories.Interface
{
    public interface IProductRepository:IRepository<Model.Product>
    {
        Product GetProductByName(string productName);
    }
}
