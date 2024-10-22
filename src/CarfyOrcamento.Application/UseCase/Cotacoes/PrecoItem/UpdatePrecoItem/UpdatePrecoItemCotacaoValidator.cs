using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.UpdatePrecoItem;

public class UpdatePrecoItemCotacaoValidator : AbstractValidator<UpdatePrecoItemCotacaoRequest>
{
    public UpdatePrecoItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty().WithMessage("ItemCotacaoId de cotação é obrigatório");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id de preço de item de cotação é obrigatório");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0");

        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("Sku é obrigatório")
            .MaximumLength(50).WithMessage("Sku deve ter no máximo 50 caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("Descrição é obrigatório")
            .MaximumLength(100).WithMessage("Descrição deve ter no máximo 100 caracteres");

        RuleFor(x => x.ValorCusto)
            .GreaterThan(0).WithMessage("ValorCusto deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0).WithMessage("ValorVenda deve ser maior que 0");

        RuleFor(x => x.PrazoExpedicao)
            .GreaterThan(0).WithMessage("PrazoExpedicao deve ser maior que 0");

        RuleFor(x => x.FornecedorId)
            .NotEmpty().WithMessage("FornecedorId é obrigatório");

        RuleFor(x => x.Fornecedor)
            .NotEmpty().WithMessage("Fornecedor é obrigatório");
    }

}