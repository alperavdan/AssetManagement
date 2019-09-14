using AssetManagement.Data.Infrastructure;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagement.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(ApplicationDbContext dbContext): base(dbContext) { }

    

        public Category GetCategoryByName(string categoryName)

        {

            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;

        }
    }
}
