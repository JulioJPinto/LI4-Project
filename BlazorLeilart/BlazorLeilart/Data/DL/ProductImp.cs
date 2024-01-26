using BlazorLeilart.Data.Interfaces;
using BlazorLeilart.Models.Products;
using Dapper;

namespace BlazorLeilart.Data.DL;

public class ProductImp : IProduct
{
    
    private readonly IDBConnection _dbConnection;
    private IProduct _productImplementation;

    public ProductImp(IDBConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<Product> GetProductByIdAsync(string id)
    {
        string query = "SELECT * FROM [product] WHERE id = @inputid";
        return await _dbConnection.Connection.QueryFirstOrDefaultAsync<Product>(query, new { inputid = id });
    }
    
    public async Task<int> ContainsKeyAsync(string id)
    {
        string query = "SELECT COUNT(*) FROM [user] WHERE id = @inputid";
        return await _dbConnection.Connection.ExecuteScalarAsync<int>(query, new { inputid = id });
    }

    public async Task<bool> PutProductAsync(Product product)
        {
            if (await ContainsKeyAsync(product.id.ToString()) == 0)
            {
                string name = product.name;
                int varietyId = product.variety_id;
                int stock = product.stock;
                string url = product.url;

                string insertQuery = "INSERT INTO [product] (name, variety_id, stock, url) VALUES (@Name, @VarietyId, @Stock, @Url)";
                await _dbConnection.Connection.ExecuteAsync(insertQuery, new { Name = name, VarietyId = varietyId, Stock = stock, Url = url });

                return true;
            }

            return false;
        }

    public async Task<bool> RemoveProductByIdAsync(string id)
    {
        if (await ContainsKeyAsync(id) != 0)
        {
            string query = "DELETE FROM [product] WHERE id = @inputId";
            await _dbConnection.Connection.ExecuteAsync(query, new { inputId = id });

            return true;
        }

        return false;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        int existingProductCount = await ContainsKeyAsync(product.id.ToString());

        if (existingProductCount > 0)
        {
            // Update the product details in the database
            string updateQuery = "UPDATE [product] SET name = @Name, variety_id = @VarietyId, stock = @Stock, url = @Url WHERE id = @Id";
            await _dbConnection.Connection.ExecuteAsync(updateQuery, new
            {
                Id = product.id,
                Name = product.name,
                VarietyId = product.variety_id,
                Stock = product.stock,
                Url = product.url
            });

            return true;
        }

        return false;
    }
    
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return (await _dbConnection.Connection.QueryAsync<Product>("SELECT * FROM [product]")).ToList();
    }
}