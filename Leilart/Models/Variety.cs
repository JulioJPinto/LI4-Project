namespace DefaultNamespace;

public class Variety
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    public Variety(int id, string nome)
    {
        this.Id = id;
        this.Nome = nome;
    }
}