using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Response;

namespace CarfyOrcamento.Core.Repositories.Clientes;

public interface IClienteRepository : IRepository<Cliente>
{
    Task AdicionarVeiculoAsync(Veiculo veiculo);
    Task RemoverVeiculoAsync(Veiculo veiculo);
    Task<PagedResponse<Cliente>> SearchAsync(string search, int pageNumber, int pageSize);
    Task<PagedResponse<Cliente>> GetAllClientesAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate = null,
        DateTime? endDate = null, string? search = null, string? orderBy = null);
}
