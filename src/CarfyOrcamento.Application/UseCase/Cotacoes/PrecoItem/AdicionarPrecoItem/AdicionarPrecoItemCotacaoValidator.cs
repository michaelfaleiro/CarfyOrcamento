using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.AdicionarPrecoItem;

public class AdicionarPrecoItemCotacaoValidator : AbstractValidator<AdicionarPrecoItemCotacaoRequest>
{
    public AdicionarPrecoItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty().WithMessage("CotaçãoId é obrigatória");

        RuleFor(x => x.ItemId)
            .NotEmpty().WithMessage("ItemCotacaoId de cotação é obrigatório");

        RuleFor(x => x.FornecedorId)
            .NotEmpty().WithMessage("FornecedorId é obrigatório");

        RuleFor(x => x.NomeFantasia)
            .NotEmpty().WithMessage("NomeFantasia é obrigatório");

        RuleFor(x => x.FabricanteId)
            .NotEmpty().WithMessage("FabricanteId é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty().WithMessage("Fabricante é obrigatório");

        RuleFor(x => x.Sku)
            .MaximumLength(50).WithMessage("Sku deve ter no máximo 50 caracteres");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

        RuleFor(x => x.ValorCusto)
            .GreaterThan(0).WithMessage("ValorCusto deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0).WithMessage("ValorVenda deve ser maior que 0");

        RuleFor(x => x.PrazoExpedicao)
            .GreaterThan(0).WithMessage("PrazoExpedicao deve ser maior que 0");
    }

}