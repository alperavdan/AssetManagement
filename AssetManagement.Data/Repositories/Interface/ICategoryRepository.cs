using AssetManagement.Data.Infrastructure;
using AssetManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Repositories.Interface
{
   public interface ICategoryRepository:IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}
