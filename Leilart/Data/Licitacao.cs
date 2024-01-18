namespace DefaultNamespace;

using System;
public class Licitacao
{
    public int Id { get; private set; }
    public int Montante { get; private set; }
    public DateTime Hora { get; private set; }
    public int IdLeilao { get; private set; }
    public int IdUser { get; private set; }

    public Licitacao(int id, int montante, int id_leilao, int id_user)
    {
        this.Id = id;
        this.Montante = montante;
        this.Hora = DateTime.Now;
        this.IdLeilao = id_leilao;
        this.IdUser = id_user;
    }
    
}