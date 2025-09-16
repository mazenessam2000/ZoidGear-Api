using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductsRepository(StoreContext context) : IProductsRepository
{
    public void AddProduct(Product product)
    {
        context.Products.AddAsync(product);
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<Product?> GetProductEntityByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await context.Products
        .Include(p => p.ProductBrand)
        .Include(p => p.ProductType)
        .FirstOrDefaultAsync(p => p.Id == id);

        return new ProductDto(
            product!.Id,
            product.Name,
            product.Description,
            product.Price,
            product.PictureUrl,
            product.ProductBrand.Name,
            product.ProductType.Name
        );
    }

    public async Task<IReadOnlyList<Product>> GetProductEntitiesAsync()
    {
        return await context.Products.ToListAsync();
    }


    public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
    {
        return await context.Products
        .Include(p => p.ProductBrand)
        .Include(p => p.ProductType)
        .Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Description,
            p.Price,
            p.PictureUrl,
            p.ProductBrand.Name,
            p.ProductType.Name
        ))
        .ToListAsync();
    }

    public bool ProductExists(int id)
    {
        return context.Products.Any(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }
}
