using CarfyOrcamento.Communication.Request.Cotacao;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Item.AdicionarItem;
public class AdicionarItemCotacaoValidator : AbstractValidator<AdicionarItemCotacaoRequest>
{
    public AdicionarItemCotacaoValidator()
    {
        RuleFor(x => x.CotacaoId)
            .NotEmpty()
            .WithMessage("CotacaoId é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatório");

        RuleFor(x => x.Quantidade)
            .NotEmpty()
            .WithMessage("Quantidade é obrigatório");

        RuleFor(x => x.TipoProduto)
            .IsInEnum()
            .WithMessage("TipoProduto é obrigatório");
    }
}
