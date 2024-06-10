using Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class SpecificationProductWithTypeAndBrands : Specification<Product>
    {
        public SpecificationProductWithTypeAndBrands(ProductSpecparameters productSpecparameters)
            :base(x=>
                  (!productSpecparameters.TypeId.HasValue || x.ProductTypeId == productSpecparameters.TypeId) &&
                  (!productSpecparameters.BrandId.HasValue || x.ProductBrandId == productSpecparameters.BrandId))
        {
            AddInClude(x=>x.productType);
            AddInClude(x => x.productBrand);
            AddOrderBy(x => x.Name);
            Pagenation(productSpecparameters.PageSize * (productSpecparameters.PageIndex - 1), productSpecparameters.PageSize);

            switch (productSpecparameters.Sort) 
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(x => x.Price);
                    break;
                
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }


        }

        public SpecificationProductWithTypeAndBrands(int id) : base(x=>x.Id == id)
        {
            AddInClude(x => x.productType);
            AddInClude(x => x.productBrand);
        }
    }
}
