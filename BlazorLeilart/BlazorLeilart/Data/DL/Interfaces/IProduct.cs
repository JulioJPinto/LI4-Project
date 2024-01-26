using BlazorLeilart.Models.Products;

namespace BlazorLeilart.Data.Interfaces;
public interface IProduct
{
    Task<Product> GetProductByIdAsync(string id);
    Task<int> ContainsKeyAsync(string id);
    Task<bool> PutProductAsync(Product product);
    Task<bool> RemoveProductByIdAsync(string id);
    Task<bool> UpdateProduct(Product product);
    Task<List<Product>> GetAllProductsAsync();
}