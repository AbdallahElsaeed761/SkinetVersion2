using Core.Entities.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            try
            {
                //if (!storeDbContext.productTypes.Any())
                //{
                //    var typeData = File.ReadAllText(@"../Infrastructure/SeedData/types.json");
                //    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);


                //    foreach (var typeEle in types)
                //    {
                //        storeDbContext.productTypes.Add(new ProductType { ProductTypeName = typeEle.ProductTypeName });
                //    }
                //    await storeDbContext.SaveChangesAsync();
                //}

                //

                //if (!storeDbContext.productBrands.Any())
                //{
                //    var brandData = File.ReadAllText(@"../Infrastructure/SeedData/brands.json");
                //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);


                //    foreach (var brand in brands)
                //    {
                //        storeDbContext.productBrands.Add(new ProductBrand { ProductBrandName = brand.ProductBrandName });
                //    }
                //    await storeDbContext.SaveChangesAsync();
                //}


                if (!storeDbContext.Products.Any())
                {
                    var productData = File.ReadAllText(@"../Infrastructure/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);


                    foreach (var prod in products)
                    {
                        storeDbContext.Products.Add(new Product
                        {
                            Name = prod.Name,
                            Description = prod.Description,
                            PictureUrl = prod.PictureUrl,
                            Price = prod.Price,
                            ProductBrandId = prod.ProductBrandId
                        ,
                            ProductTypeId = prod.ProductTypeId
                        });
                    }
                    await storeDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
