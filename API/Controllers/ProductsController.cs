using API.DTOS;
using API.Error;
using AutoMapper;
using Core.Entities.Products;
using Core.Interfaces;
using Core.Specification;
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
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepos;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo , IGenericRepository<ProductBrand> BrandRepos
            ,IGenericRepository<ProductType> TypeRepo , IMapper mapper)
        {
            productRepo = ProductRepo;
            brandRepos = BrandRepos;
            typeRepo = TypeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> getProduct()
        {
            var Included = new SpecificationProductWithTypeAndBrands();
            var products =await productRepo.ListAllAsyncSpecification(Included);
            return Ok(mapper.Map<List<Product>, List<ProductDto>>((List<Product>)products));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> getProductById(int id)
        {
            var Included = new SpecificationProductWithTypeAndBrands(id);

            var product = await productRepo.GetByIdAsyncWithSpecification(Included);

            if (product == null)
            {
                return NotFound(new ApiResponse(400));
            }
            
            return Ok(mapper.Map<Product, ProductDto>(product));
        }

        [HttpGet("getProductBrands")]
        public async Task<ActionResult<List<ProductBrand>>> getProductBrands()
        {
            var productsbrands = await brandRepos.ListAllAsync();
            return Ok(productsbrands);
        }
        [HttpGet("getProductTypes")]
        public async Task<ActionResult<List<ProductType>>> getProductTypes()
        {
            var productsTypes = await typeRepo.ListAllAsync();
            return Ok(productsTypes);
        }
    }
}
