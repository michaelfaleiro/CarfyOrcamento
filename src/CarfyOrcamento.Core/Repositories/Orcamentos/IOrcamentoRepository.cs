using CarfyOrcamento.Core.Entities;

namespace CarfyOrcamento.Core.Repositories.Orcamentos;

public interface IOrcamentoRepository : IRepository<Orcamento>
{
    Task AdicionarItemAsync(ItemOrcamento item);
    Task AtualizarItemAsync(ItemOrcamento item);    
    Task RemoverItemAsync(ItemOrcamento item);
    Task AdicionarItemAvulsoAsync(ItemAvulsoOrcamento item);
    Task AtualizarItemAvulsoAsync(ItemAvulsoOrcamento item);
    Task RemoverItemAvulsoAsync(ItemAvulsoOrcamento item);
    
}