using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Item.UpdateItem;

public class UpdateItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public UpdateItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(UpdateItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                   ?? throw new NotFoundException("Item não encontrado");

        var item = orcamento.Itens.FirstOrDefault(x => x.Id == request.Id)
                   ?? throw new NotFoundException("Item não encontrado");

        item.Atualizar(
            request.ProdutoId,
            request.FabricanteId,
            request.Fabricante,
            request.Sku,
            request.Descricao,
            request.Quantidade,
            request.ValorVenda
        );

        await _orcamentoRepository.AtualizarItemAsync(item);
    }

    private void Validate(UpdateItemOrcamentoRequest request)
    {
        var validator = new UpdateItemOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}