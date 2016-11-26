using finance_home_system.Products;
using ProductsApi.Repository;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using finance_home_system.Category;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IProductsRepository ProductsRepo { get; set; }

        public ProductsController(IProductsRepository _repo)
        {
            ProductsRepo = _repo;
        }

        [HttpGet]
        public  IEnumerable<object> GetAll()
        {

            return ProductsRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public IActionResult GetById(string id)
        {
            var item = ProductsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Products item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ProductsRepo.Add(item);
            return CreatedAtRoute("GetProducts", new { Controller = "Products", id = item.ProductsId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Products item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var productObj = ProductsRepo.Find(id);
            if (productObj == null)
            {
                return NotFound();
            }
            ProductsRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ProductsRepo.Remove(id);
        }
    }
}