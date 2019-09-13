using AssetManagement.Data.Infrastructure;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Service.Shared.CategoryService;
using AssetManagement.Service.Shared.CategoryService.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Service.Category
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,IMapper mapper)

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

        public void CreateCategory(CategoryDto category)

        {

            categoryRepository.Add(_mapper.Map<Model.Category>(category));

        }

        public void UpdateCategory(CategoryDto category)

        {

            categoryRepository.Update(_mapper.Map<Model.Category>(category));

        }

        public void DeleteCategory(long id)

        {

            categoryRepository.Delete(pc => pc.Id == id);

        }

        public void SaveCategory()

        {

            unitOfWork.Commit();

        }

        #endregion
    }
}
