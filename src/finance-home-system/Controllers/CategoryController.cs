using CategoryApi.Repository;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using finance_home_system.Category;

namespace CategoryApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public ICategoryRepository CategoryRepo { get; set; }

        public CategoryController(ICategoryRepository _repo)
        {
            CategoryRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<categoryList> GetCategory()
        {
            return CategoryRepo.GetCategory();
        }
    }
}