using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.AdicionarCodigoEquivalente;

public class AdicionarCodigoEquivalenteValidator : AbstractValidator<AdicionarCodigoEquivalenteRequest>
{
    public AdicionarCodigoEquivalenteValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty()
            .WithMessage("Cotação é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item é obrigatório");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU é obrigatório");

        RuleFor(x => x.FabricanteId)
            .NotEmpty()
            .WithMessage("Fabricante é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("Nome do fabricante é obrigatório");

        RuleFor(x => x.TipoProdutoEquivalente)
            .IsInEnum()
            .WithMessage("Tipo de produto equivalente inválido");
    }
    
}