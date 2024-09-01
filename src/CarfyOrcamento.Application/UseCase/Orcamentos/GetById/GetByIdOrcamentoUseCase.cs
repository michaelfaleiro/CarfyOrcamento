using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.ItemOrcamento;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.GetById;

public class GetByIdOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public GetByIdOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task<ResponseJson<ResponseOrcamentoJson>> ExecuteAsync(Guid id)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(id) 
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        return new ResponseJson<ResponseOrcamentoJson>(new ResponseOrcamentoJson(
            orcamento.Id,
            orcamento.ClienteId,
            orcamento.VeiculoId,
            orcamento.VendedorId,
            orcamento.Itens.Select(item => new ResponseItemOrcamentoJson(
                item.Id,
                item.Sku,
                item.Descricao,
                item.Quantidade,
                item.ValorVenda
            )).ToList(),
            orcamento.ItensAvulsos.Select(item => new ResponseItemAvulsoOrcamentoJson(
                item.Id,
                orcamento.Id,
                item.Sku,
                item.Descricao,
                item.ValorVenda,
                item.Quantidade,
                item.CreatedAt,
                item.UpdatedAt
            )).ToList(),
            orcamento.CreatedAt,
            orcamento.UpdatedAt
        ));
    }
}