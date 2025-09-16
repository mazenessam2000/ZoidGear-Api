using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductTypes.Any() && !context.ProductBrands.Any() && !context.Products.Any())
        {
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (products is not null && products.Any())
            {
                var types = products.Select(p => p.ProductType).DistinctBy(t => t.Name).ToList();
                await context.ProductTypes.AddRangeAsync(types);

                var brands = products.Select(p => p.ProductBrand).DistinctBy(b => b.Name).ToList();
                await context.ProductBrands.AddRangeAsync(brands);

                foreach (var product in products)
                {
                    product.ProductType = types.First(t => t.Name == product.ProductType.Name);
                    product.ProductBrand = brands.First(b => b.Name == product.ProductBrand.Name);
                }

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}

