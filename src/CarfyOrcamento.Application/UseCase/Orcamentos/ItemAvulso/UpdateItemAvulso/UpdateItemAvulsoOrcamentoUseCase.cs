using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.UpdateItemAvulso;

public class UpdateItemAvulsoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public UpdateItemAvulsoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(UpdateItemAvulsoOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                        ?? throw new NotFoundException("Orcamento não encontrado");

        var item = orcamento.ItensAvulsos.FirstOrDefault(i => i.Id == request.ItemAvulsoId)
                   ?? throw new NotFoundException("Item avulso não encontrado");

        orcamento.UpdatedAt = DateTime.UtcNow;

        item.Atualizar(request.FabricanteId, request.Sku, request.Fabricante, request.Quantidade,
            request.Descricao, request.ValorVenda);

        await _orcamentoRepository.AtualizarItemAvulsoAsync(item);
    }

    private void Validate(UpdateItemAvulsoOrcamentoRequest request)
    {
        var validator = new UpdateItemAvulsoOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}