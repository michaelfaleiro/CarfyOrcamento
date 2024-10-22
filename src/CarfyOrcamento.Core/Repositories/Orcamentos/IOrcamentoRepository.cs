using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Response;

namespace CarfyOrcamento.Core.Repositories.Orcamentos;

public interface IOrcamentoRepository : IRepository<Orcamento>
{
    Task<PagedResponse<Orcamento>> GetAllAsync(int pageNumber, int pageSize, string? status = null, string? orderBy = null);
    Task AdicionarItemAsync(ItemOrcamento item);
    Task AtualizarItemAsync(ItemOrcamento item);    
    Task RemoverItemAsync(ItemOrcamento item);
    Task AdicionarItemAvulsoAsync(ItemAvulsoOrcamento item);
    Task AtualizarItemAvulsoAsync(ItemAvulsoOrcamento item);
    Task RemoverItemAvulsoAsync(ItemAvulsoOrcamento item);

}