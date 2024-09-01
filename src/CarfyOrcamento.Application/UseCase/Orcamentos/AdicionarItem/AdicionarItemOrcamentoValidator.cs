using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.AdicionarItem;

public class AdicionarItemOrcamentoValidator : AbstractValidator<AdicionarItemOrcamentoRequest>
{
    public AdicionarItemOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("O id do orçamento é obrigatório.");

        RuleFor(x => x.ProdutoId)
            .NotEmpty()
            .WithMessage("O id do produto é obrigatório.");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("A descrição é obrigatória.");
        
        RuleFor(x => x.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que zero.");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("O valor de venda deve ser maior que zero.");
    }
    
}