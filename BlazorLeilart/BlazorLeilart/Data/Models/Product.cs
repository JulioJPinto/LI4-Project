namespace BlazorLeilart.Models.Products;

public class Product
{
    public int Id { get; private set; }
    public string name { get; private set; }
    public int IdVariety { get; private set; }
    public int Stock { get; private set; }
    
    public Product(int id, string name, int categoria, int stock)
    {
        this.Id = id;
        this.name = name;
        this.IdVariety = categoria;
        this.Stock = stock;
    }
    
    public Product()
    {
        this.Id = 1;
        this.name = "Teste";
        this.IdVariety = 2;
        this.Stock = 3;
    }
}