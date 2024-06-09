using Core.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        
        public decimal Price { get; set; }
        public string? productBrand { get; set; }
        public string? productType { get; set; }
       
    }
}
