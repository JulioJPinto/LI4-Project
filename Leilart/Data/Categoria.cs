namespace DefaultNamespace;

public class Categoria
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    public Categoria(int id, string nome)
    {
        this.Id = id;
        this.Nome = nome;
    }
}