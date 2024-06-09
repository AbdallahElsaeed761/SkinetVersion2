using Core.Entities.Products;
using Core.Interfaces;
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
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProduct()
        {
            var products =await _productRepository.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("getProductBrands")]
        public async Task<ActionResult<List<ProductBrand>>> getProductBrands()
        {
            var productsbrands = await _productRepository.GetProductBrandsAsync();
            return Ok(productsbrands);
        }
        [HttpGet("getProductTypes")]
        public async Task<ActionResult<List<ProductType>>> getProductTypes()
        {
            var productsTypes = await _productRepository.GetProductTypesAsync();
            return Ok(productsTypes);
        }
    }
}
