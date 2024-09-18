using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Item.UpdateItem;

public class UpdateItemOrcamentoValidator : AbstractValidator<UpdateItemOrcamentoRequest>
{
    public UpdateItemOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id é obrigatório");

        RuleFor(x => x.ProdutoId)
            .NotEmpty()
            .WithMessage("ProdutoId é obrigatório");

        RuleFor(x => x.FabricanteId)
            .NotEmpty()
            .WithMessage("FabricanteId é obrigatório");

        RuleFor(x => x.Fabricante)
            .NotEmpty()
            .WithMessage("Fabricante é obrigatório");

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descricao é obrigatório");

        RuleFor(x => x.Quantidade)
            .GreaterThan(0)
            .WithMessage("Quantidade deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(0)
            .WithMessage("ValorVenda deve ser maior que 0");
    }
}