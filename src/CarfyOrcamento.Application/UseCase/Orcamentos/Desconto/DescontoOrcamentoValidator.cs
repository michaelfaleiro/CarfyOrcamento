using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;

public class DescontoOrcamentoValidator : AbstractValidator<AdicionarDescontoOrcamentoRequest>
{
    public DescontoOrcamentoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id do orçamento é obrigatório");

        RuleFor(x => x.ValorDesconto)
            .GreaterThanOrEqualTo(0).WithMessage("O valor do desconto deve ser maior ou igual a 0");
    }
    
}