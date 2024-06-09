using API.DTOS;
using AutoMapper;
using Core.Entities.Products;

namespace API.HelperInAPI
{
    public class ProductValueResolve : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductValueResolve(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return configuration.GetSection("ApiUrl").Value + source.PictureUrl;
            }
            return null;
        }
    }
}
