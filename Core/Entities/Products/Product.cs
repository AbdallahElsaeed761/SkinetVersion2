using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Products
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public ProductBrand? productBrand { get; set; }
        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
        public ProductType? productType { get; set; }
        public int ProductTypeId { get; set; }

       
    }
}
