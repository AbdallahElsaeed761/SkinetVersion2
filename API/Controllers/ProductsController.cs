using Core.Entities.Products;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _storeDbContext;

        public ProductsController(StoreDbContext storeDbContext)
        {
            this._storeDbContext = storeDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProduct()
        {
            var products =await _storeDbContext.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            var product = await _storeDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
