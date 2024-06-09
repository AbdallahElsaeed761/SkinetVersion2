using Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class SpecificationProductWithTypeAndBrands : Specification<Product>
    {
        public SpecificationProductWithTypeAndBrands()
        {
            AddInClude(x=>x.productType);
            AddInClude(x=>x.productBrand);
        }

        public SpecificationProductWithTypeAndBrands(int id) : base(x=>x.Id == id)
        {
            AddInClude(x => x.productType);
            AddInClude(x => x.productBrand);
        }
    }
}
