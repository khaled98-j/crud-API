using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product {Id = 1, Name ="Phon", Description="joe"},
            new Product {Id = 2, Name ="Phon2", Description="joe"},
            new Product {Id = 3, Name ="Phon3", Description="joe"}

        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.First(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var product = new Product {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Product request)
        {
            var curnetProduct = products.FirstOrDefault(x => x.Id == id);
            if(curnetProduct == null)
            {
                return NotFound();
            }

            curnetProduct.Name = request.Name;
            curnetProduct.Description = request.Description;

            return Ok(curnetProduct);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var curnetProduct = products.FirstOrDefault(x => x.Id == id);
            if (curnetProduct == null)
            {
                return NotFound();
            }
            products.Remove(curnetProduct);

            return Ok(curnetProduct);

        }

    }
}
