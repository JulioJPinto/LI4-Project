namespace DefaultNamespace;

public class Peca
{
    public int Id { get; private set; }
    public int IdCategoria { get; private set; }
    public int Stock { get; private set; }

    public Peca(int id, int categoria, int stock)
    {
        this.Id = id;
        this.IdCategoria = categoria;
        this.Stock = stock;
    }
}