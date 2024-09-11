using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.RemoverItemAvulso;

public class RemoverItemAvulsoOrcamentoValidator : AbstractValidator<RemoverItemAvulsoOrcamentoRequest>
{
    public RemoverItemAvulsoOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.ItemAvulsoId)
            .NotEmpty()
            .WithMessage("ItemAvulsoId é obrigatório");
    }
    
}