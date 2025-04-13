using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;


namespace NewPharmacy.Endpoints.ProductEndpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostProductEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostProductEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            // Provjeri da li kategorija postoji u bazi
            var category = _context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

            if (category == null)
            {
                return BadRequest("Category not found");
            }

            // Poveži kategoriju s proizvodom
            product.Category = category;

            // Dodaj proizvod u bazu
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);


        }


    }
}