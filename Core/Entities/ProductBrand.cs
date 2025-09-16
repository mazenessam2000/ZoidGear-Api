using System.Text.Json.Serialization;

namespace Core.Entities;

public class ProductBrand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    /*
        // Logo URL
        public string? LogoUrl { get; set; }
    */
    // One-to-Many relationship with Products
    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
