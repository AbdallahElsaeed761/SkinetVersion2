using Core.Entities.Products;
using Core.Helper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Infrastructure.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // // Seed data for ProductBrands
            //var brandData =  File.ReadAllText("../Infrastructure/SeedData/brands.json");
            // var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

            // foreach (var brand in brands)
            // {
            //     modelBuilder.Entity<ProductBrand>().HasData
            //         (new ProductBrand {  ProductBrandName = brand.ProductBrandName });
            // };

            //var res = await ReadJsonFile.LoadJson("../Infrastructure/SeedData/types.json");
            int id = 1; // Start with a positive value

            //foreach (var itemtype in res)
            //{
            //    modelBuilder.Entity<ProductType>().HasData(new ProductType
            //    {
            //        Id = id++,
            //        ProductTypeName = itemtype.ProductTypeName
            //    });
            //}

            var productData = await ReadJsonFile.LoadJson(@"../Infrastructure/SeedData/products.json");
            


            foreach (var prod in productData)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = id++,
                    Name = prod.Name,
                    Description = prod.Description,
                    PictureUrl = prod.PictureUrl,
                    Price = prod.Price,
                    ProductBrandId = prod.ProductBrandId
                ,
                    ProductTypeId = prod.ProductTypeId
                });
            }
            //var brandsdata = await ReadJsonFile.LoadJson("../Infrastructure/SeedData/brands.json");
            //int id = 1; // Start with a positive value

            //foreach (var itembrand in brandsdata)
            //{
            //    modelBuilder.Entity<ProductBrand>().HasData(new ProductBrand
            //    {
            //        Id = id++,
            //        ProductBrandName = itembrand.ProductBrandName
            //    });
            //}

            //// Seed data for Types
            //var productsData = File.ReadAllText("../Infrastructure/SeedData/products.json");
            //var Products = JsonSerializer.Deserialize<List<Product>>(productsData);

            //foreach (var product in Products)
            //{
            //    modelBuilder.Entity<Product>().HasData
            //        (new Product {  Name = product.Name, Description = product.Description,
            //                        PictureUrl = product.PictureUrl, Price = product.Price , ProductBrandId = product.ProductBrandId,
            //                               ProductTypeId = product.ProductTypeId});
            //};
            //Change any column decimal type to double 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                                           .Where(p => p.ClrType == typeof(decimal));

                foreach (var property in properties)
                {
                    // Change the type from decimal to double
                    modelBuilder.Entity(entityType.ClrType).Property(property.Name).HasConversion<double>();
                }
            }



        }
    }

    
}
