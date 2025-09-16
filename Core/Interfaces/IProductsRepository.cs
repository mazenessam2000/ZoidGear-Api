using Core.Entities;

namespace Core.Interfaces;

public interface IProductsRepository
{
    Task<IReadOnlyList<ProductDto>> GetProductsAsync(int? brandId, int? typeId, string? sort);
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<Product?> GetProductEntityByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);
    Task SaveChangesAsync();
}
