namespace CarfyOrcamento.Core.Entities;

public class Cotacao : Entity
{
    private Cotacao()
    {
        Itens = [];
    }

    public Cotacao(Orcamento orcamento,  StatusCotacao status)
    {
        Orcamento = orcamento;
        Status = status;
        Itens = [];
    }

    public Orcamento Orcamento { get; set; } = null!;
    public IList<ItemCotacao> Itens { get; set; } 
    public StatusCotacao Status { get; set; } = null!;
}