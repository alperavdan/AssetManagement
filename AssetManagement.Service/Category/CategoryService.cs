using AssetManagement.Data.Infrastructure;
using AssetManagement.Model;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Service.Shared.CategoryService;
using AssetManagement.Service.Shared.CategoryService.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AssetManagement.Service.Category
{
    public class CategoryService:ICategoryService
    {

        private readonly IRepository<Model.Category> categoryRepository;
       
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Model.Category> categoryRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = categoryRepository.GetAll();
            return  _mapper.Map<List<CategoryDto>>(categories);
        }

        public CategoryDto GetCategory(long id)
        {
            var category = categoryRepository.GetById(id);

            return _mapper.Map<CategoryDto>(category);
        }
        public CategoryDto GetCategoryByName()
        {
            var category = categoryRepository.GetAll().FirstOrDefault(x => x.Name == "alper");

            return _mapper.Map<CategoryDto>(category);
        }
        public void CreateCategory(CategoryDto category)
        {
            categoryRepository.Add(_mapper.Map<Model.Category>(category));
            unitOfWork.Commit();
        }

        public void UpdateCategory(CategoryDto category)

        {

            categoryRepository.Update(_mapper.Map<Model.Category>(category));

        }

        public void DeleteCategory(long id)

        {

            categoryRepository.Delete(pc => pc.Id == id);
            unitOfWork.Commit();

        }

        //public void SaveCategory()

        //{

        //    unitOfWork.Commit();

        //}

        #endregion
    }
}
