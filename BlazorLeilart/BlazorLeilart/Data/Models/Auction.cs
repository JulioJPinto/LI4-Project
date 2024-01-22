using BlazorLeilart.Models.Products;

namespace BlazorLeilart.Models.Auction;

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
    
    public Product Product { get; set; }

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
        this.Product = null;
    }

    public Auction()
    {
        this.Id = -1;
        this.TipoLeilao = -1;
        this.IdProduto = -1;
        this.ValorMinimo = -1;
        this.ValorInicial = -1;
        this.Incremento = -1;
        this.Inicio = System.DateTime.Now;
        this.Fim = System.DateTime.Now;
        this.LicitacaoAtual = -1;
        this.Estado = false;
        this.Product = null;
    }
    

}
