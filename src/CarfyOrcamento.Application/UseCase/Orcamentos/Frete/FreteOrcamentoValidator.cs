using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Frete;

public class FreteOrcamentoValidator : AbstractValidator<AdicionarFreteRequest>
{
    public FreteOrcamentoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id do orçamento é obrigatório");

        RuleFor(x => x.ValorFrete)
            .NotEmpty()
            .WithMessage("Valor do frete é obrigatório")
            .GreaterThan(0)
            .WithMessage("Valor do frete deve ser maior que 0");
    }
    
}