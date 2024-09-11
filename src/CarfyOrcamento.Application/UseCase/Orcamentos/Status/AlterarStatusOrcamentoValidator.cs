using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Status;
public class AlterarStatusOrcamentoValidator : AbstractValidator<AlterarStatusOrcamentoRequest>
{
    public AlterarStatusOrcamentoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id do orçamento é obrigatório");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status inválido");
    }
}
