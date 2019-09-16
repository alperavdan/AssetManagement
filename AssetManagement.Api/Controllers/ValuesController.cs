using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AssetManagement.Service.Shared.CategoryService;
using AssetManagement.Service.Shared.ProductService;
using Log4Net_Logging;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ValuesController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
          
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _categoryService.CreateCategory(new Service.Shared.CategoryService.Dto.CategoryDto { Name = "aaa", AddedDate = DateTime.Now, AddedBy = "alper" });
            _categoryService.GetCategoryByName();
            _productService.CreateProduct(new Service.Shared.ProductService.Dto.ProductDto { Title = "avdan",CategoryId=1,Description="aaaasdaasd" });
            //_categoryService.SaveCategory();
           
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
