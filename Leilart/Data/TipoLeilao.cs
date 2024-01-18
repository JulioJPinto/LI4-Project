namespace DefaultNamespace;

public class TipoLeilao
{
    public int Id { get; private set; }
    public string Nome { get; private set; }

    public TipoLeilao(int id, string nome)
    {
        this.Id = id;
        this.Nome = nome;
    }
    
}