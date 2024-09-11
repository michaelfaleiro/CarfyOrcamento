using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Core.Entities;

public class Cotacao : Entity
{
    private Cotacao()
    {
        Itens = [];
    }

    public Cotacao(Orcamento orcamento, EStatusCotacao status)
    {
        Orcamento = orcamento;
        Status = status;
        Itens = [];
    }

    public Orcamento Orcamento { get; set; } = null!;
    public IEnumerable<ItemCotacao> Itens { get; set; }
    public EStatusCotacao Status { get; set; }
}