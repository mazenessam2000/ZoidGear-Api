namespace Core.Entities;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string PictureUrl,
    string Brand,
    string Type
);
// Note: Consider adding additional properties or methods if needed in the future.  
