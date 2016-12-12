using finance_home_system.Products;
using ProductsApi.Repository;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using finance_home_system.Categories;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public IProductRepository ProductRepo { get; set; }

        public ProductController(IProductRepository _repo)
        {
            ProductRepo = _repo;
        }

        [HttpGet]
        public  IEnumerable<Product> GetAll()
        {

            return ProductRepo.GetAll();
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(string id)
        {
            var item = ProductRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ProductRepo.Add(item);
            return CreatedAtRoute("GetProduct", new { Controller = "Product", id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var productObj = ProductRepo.Find(id);
            if (productObj == null)
            {
                return NotFound();
            }
            ProductRepo.Update(item);
            return new NoContentResult();
        }
    }
}