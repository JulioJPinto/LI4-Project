namespace DefaultNamespace;

using System;

public class Auction
{
    public int Id { get; private set; }
    public int TipoLeilao { get; private set; }
    public int IdProduto { get; private set; }
    public int? ValorMinimo { get; private set; }
    public int? ValorInicial { get; private set; }
    public int? Incremento { get; private set; }
    public DateTime Inicio { get; private set; }
    public DateTime Fim { get; private set; }
    public int? LicitacaoAtual { get; private set; }
    public bool Estado { get; private set; }

    public Auction(int id, int tipo_leilao, int produto, int valor_minimo, int valor_inicial, int incremento, DateTime inicio, DateTime fim, int licitacao_atual, bool estado)
    {
        this.Id = id;
        this.TipoLeilao = tipo_leilao;
        this.IdProduto = produto;
        this.ValorMinimo = valor_minimo;
        this.ValorInicial = valor_inicial;
        this.Incremento = incremento;
        this.Inicio = inicio;
        this.Fim = fim;
        this.LicitacaoAtual = licitacao_atual;
        this.Estado = estado;
    }

}
