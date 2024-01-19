namespace DefaultNamespace;

public class Product
{
    public int Id { get; private set; }
    public int IdCategoria { get; private set; }
    public int Stock { get; private set; }

    public Product(int id, int categoria, int stock)
    {
        this.Id = id;
        this.IdCategoria = categoria;
        this.Stock = stock;
    }
}