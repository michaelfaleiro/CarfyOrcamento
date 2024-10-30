using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;

public class CupomDescontoValidator : AbstractValidator<AdicionarCupomDescontoOrcamentoRequest>
{
    public CupomDescontoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório");

        RuleFor(x => x.CupomDesconto)
            .GreaterThanOrEqualTo(0).WithMessage("O valor do desconto deve ser maior ou igual a 0");
    }
    
}