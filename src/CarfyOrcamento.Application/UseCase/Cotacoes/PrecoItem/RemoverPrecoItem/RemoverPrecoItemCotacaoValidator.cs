using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.RemoverPrecoItem;

public class RemoverPrecoItemCotacaoValidator : AbstractValidator<RemoverPrecoItemCotacaoRequest>
{
    public RemoverPrecoItemCotacaoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório");

        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty().WithMessage("ItemCotacaoId é obrigatório");
    }

}