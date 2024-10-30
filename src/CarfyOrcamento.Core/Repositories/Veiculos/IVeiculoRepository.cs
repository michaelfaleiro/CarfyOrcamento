using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Response;

namespace CarfyOrcamento.Core.Repositories.Veiculos;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<PagedResponse<Veiculo>> GetAllVeiculosAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate = null,
        DateTime? endDate = null, string? search = null, string? orderBy = null);
}