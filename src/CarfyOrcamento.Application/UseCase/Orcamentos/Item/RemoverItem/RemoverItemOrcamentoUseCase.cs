using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Item.RemoverItem;

public class RemoverItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public RemoverItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(RemoverItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                        ?? throw new NotFoundException("Orçamento não encontrado");

        var item = orcamento.Itens.FirstOrDefault(x => x.Id == request.ItemOrcamentoId)
                   ?? throw new NotFoundException("Item não encontrado");

        orcamento.UpdatedAt = DateTime.UtcNow;

        await _orcamentoRepository.RemoverItemAsync(item);
    }

    private void Validate(RemoverItemOrcamentoRequest request)
    {
        var validator = new RemoverItemOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}