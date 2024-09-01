using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.RemoverItem;

public class RemoverItemOrcamentoValidator : AbstractValidator<RemoverItemOrcamentoRequest>
{
    public RemoverItemOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("O id do orçamento é obrigatório.");

        RuleFor(x => x.ItemOrcamentoId)
            .NotEmpty()
            .WithMessage("O id do item do orçamento é obrigatório.");
    }
    
}