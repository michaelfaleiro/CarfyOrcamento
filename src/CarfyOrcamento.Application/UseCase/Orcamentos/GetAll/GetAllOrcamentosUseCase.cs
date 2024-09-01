using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Core.Repositories.Orcamentos;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;

public class GetAllOrcamentosUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public GetAllOrcamentosUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task<PagedResponse<ResponseOrcamentoShortJson>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var orcamentos = await _orcamentoRepository.GetAllAsync(pageNumber, pageSize);
       
        return new PagedResponse<ResponseOrcamentoShortJson>(orcamentos.Data.Select(orcamento => new ResponseOrcamentoShortJson(
            orcamento.Id,
            orcamento.ClienteId,
            orcamento.VeiculoId,
            orcamento.VendedorId,
            orcamento.CreatedAt,
            orcamento.UpdatedAt
        )).ToList(), orcamentos.TotalCount, pageNumber, pageSize);
    }
}