using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.UpdateItem;

public class UpdateItemCotacaoValidator : AbstractValidator<UpdateItemCotacaoRequest>
{
    public UpdateItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ItemId de cotação é obrigatório");

        RuleFor(x => x.Sku)
            .MaximumLength(50).WithMessage("Sku deve ter no máximo 50 caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("Descrição é obrigatória")
            .MaximumLength(100).WithMessage("Descrição deve ter no máximo 100 caracteres");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0");

        RuleFor(x => x.TipoProduto)
            .IsInEnum().WithMessage("Tipo de produto inválido");
    }

}