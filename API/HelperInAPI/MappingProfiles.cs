using API.DTOS;
using AutoMapper;
using Core.Entities.Products;

namespace API.HelperInAPI
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.productBrand, o => o.MapFrom(a => a.productBrand.ProductBrandName))
                .ForMember(x => x.productType, o => o.MapFrom(a => a.productType.ProductTypeName))
                .ForMember(x=>x.PictureUrl , o=>o.MapFrom<ProductValueResolve>());
           // CreateMap<ProductDto, Product>();
        }
    }
}
