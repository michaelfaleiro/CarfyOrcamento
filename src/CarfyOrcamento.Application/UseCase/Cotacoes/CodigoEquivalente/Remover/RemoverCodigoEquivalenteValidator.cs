using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Delete;

public class RemoverCodigoEquivalenteValidator : AbstractValidator<RemoverCodigoEquivalenteRequest>
{
    public RemoverCodigoEquivalenteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id é obrigatório");

        RuleFor(x => x.CotacaoId)
            .NotEmpty()
            .WithMessage("Cotação é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item é obrigatório");
    }
    
}