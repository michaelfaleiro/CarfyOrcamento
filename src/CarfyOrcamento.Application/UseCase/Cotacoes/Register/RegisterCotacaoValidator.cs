using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Register;

public class RegisterCotacaoValidator : AbstractValidator<RegisterCotacaoRequest>
{
    public RegisterCotacaoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");
        
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status é obrigatório");
    }
}
