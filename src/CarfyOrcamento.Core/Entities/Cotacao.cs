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
        OrcamentoId = orcamento.Id;
        Status = status;
        Itens = [];
    }

    public Guid OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; } = null!;
    public IList<ItemCotacao> Itens { get; set; }
    public EStatusCotacao Status { get; set; }
    
    public void AlterarStatus(EStatusCotacao status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }
}