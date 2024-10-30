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
            .GreaterThanOrEqualTo(0).WithMessage("O valor do desconto deve ser maior ou igual a 0");
    }
    
}