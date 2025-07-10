namespace BestStoreMVC.Models
{
    public class ProductsDtoClass
    {
        public required string Name { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageFileName { get; set; }
    }
}
