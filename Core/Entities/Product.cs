namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public int StockQuantity { get; set; }


    // Foreign Keys
    public int ProductBrandId { get; set; }
    public int ProductTypeId { get; set; }

    // Navigation Properties
    public required ProductBrand ProductBrand { get; set; }
    public required ProductType ProductType { get; set; }

    // Optional Extras
     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}