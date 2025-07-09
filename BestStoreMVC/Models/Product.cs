using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
       
        public required string Name { get; set; } 
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageFileName { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
