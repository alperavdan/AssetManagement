using AssetManagement.Service.Shared.CategoryService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Shared.CategoryService
{
    public interface ICategoryService

    {

        CategoryDto GetCategory(long id);
        CategoryDto GetCategoryByName();

        IEnumerable<CategoryDto> GetCategories();

        void CreateCategory(CategoryDto category);

        void UpdateCategory(CategoryDto category);

        void DeleteCategory(long id);



    }
}
