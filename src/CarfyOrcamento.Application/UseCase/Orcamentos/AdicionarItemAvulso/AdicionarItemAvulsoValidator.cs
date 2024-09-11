using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.AdicionarItemAvulso;

public class AdicionarItemAvulsoValidator : AbstractValidator<AdicionarItemAvulsoOrcamentoRequest>
{
    public AdicionarItemAvulsoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku é obrigatório");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0)
            .WithMessage("Quantidade deve ser maior que 0");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("Valor de venda deve ser maior que 0");
        
        RuleFor(x => x.FabricanteId)
            .NotEmpty()
            .WithMessage("O id do fabricante é obrigatório.");
        
        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("O fabricante é obrigatório.");
    }
    
}