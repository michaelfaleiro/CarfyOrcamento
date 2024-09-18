using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.RemoverItem;

public class RemoverItemCotacaoValidator : AbstractValidator<RemoverItemCotacaoRequest>
{
    public RemoverItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty().WithMessage("ItemId de cotação é obrigatório");
    }

}