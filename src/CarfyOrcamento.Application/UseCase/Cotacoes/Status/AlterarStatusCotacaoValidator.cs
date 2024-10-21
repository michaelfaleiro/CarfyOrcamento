using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Status;

public class AlterarStatusCotacaoValidator : AbstractValidator<AlterarStatusCotacaoRequest>
{
    public AlterarStatusCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status é obrigatório");
    }
    
}