using Core.Entities;

namespace Core.Interfaces;

public interface IProductsRepository
{
    Task<IReadOnlyList<ProductDto>> GetProductsAsync();
    Task<IReadOnlyList<Product>> GetProductEntitiesAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<Product?> GetProductEntityByIdAsync(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);
    Task SaveChangesAsync();
}
