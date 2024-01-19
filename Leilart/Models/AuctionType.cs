namespace DefaultNamespace;

public class AuctionType
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    public AuctionType(int id, string nome)
    {
        this.Id = id;
        this.Nome = nome;
    }
    
}