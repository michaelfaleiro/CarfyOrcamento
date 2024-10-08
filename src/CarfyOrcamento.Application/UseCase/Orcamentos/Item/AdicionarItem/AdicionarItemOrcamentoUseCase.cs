using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Item.AdicionarItem;

public class AdicionarItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AdicionarItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AdicionarItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        orcamento.UpdatedAt = DateTime.UtcNow;

        var item = new ItemOrcamento(request.ProdutoId, request.FabricanteId, request.Fabricante, request.Sku,
            request.Descricao, request.Quantidade, request.ValorVenda, orcamento);

        await _orcamentoRepository.AdicionarItemAsync(item);
    }

    private void Validate(AdicionarItemOrcamentoRequest request)
    {
        var validator = new AdicionarItemOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}