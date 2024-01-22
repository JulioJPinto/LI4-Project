namespace BlazorLeilart.Models.Products;

public class Product
{
    public int id { get; private set; }
    public string name { get; private set; }
    public int variety_id { get; private set; }
    public int stock { get; private set; }
    
    public string url { get; private set; }
    
    public Product(int id, string name, int categoria, int stock, string url)
    {
        this.id = id;
        this.name = name;
        this.variety_id = categoria;
        this.stock = stock;
        this.url = url;
    }
    
    public Product()
    {
        this.id = 1;
        this.name = "Teste";
        this.variety_id = 2;
        this.stock = 3;
        this.url = "https://placehold.co/600";
    }
}