using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
         private readonly SupabaseService _supabaseService;

        public ProductController(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _supabaseService.GetAllProducts();
            // return Ok(products);
            var serializedProducts = JsonConvert.SerializeObject(products);
            return Ok(serializedProducts);

        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _supabaseService.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            var serializedProduct = JsonConvert.SerializeObject(product);

            return Ok(serializedProduct);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var addedProduct = await _supabaseService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.id }, addedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deleted = await _supabaseService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok("Deleted Succesfully"); // 204 No Content response
        }
    }
}