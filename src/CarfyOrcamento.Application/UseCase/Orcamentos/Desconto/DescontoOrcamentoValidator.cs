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
            .NotEmpty()
            .WithMessage("Valor do desconto é obrigatório")
            .GreaterThan(0)
            .WithMessage("Valor do desconto deve ser maior que 0");
    }
    
}