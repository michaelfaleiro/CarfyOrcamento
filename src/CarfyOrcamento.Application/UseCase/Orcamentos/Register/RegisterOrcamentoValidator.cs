using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Register;

public class RegisterOrcamentoValidator : AbstractValidator<RegisterOrcamentoRequest>
{
    public RegisterOrcamentoValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEmpty()
            .WithMessage("ClienteId é obrigatório");

        RuleFor(x => x.VeiculoId)
            .NotEmpty()
            .WithMessage("VeiculoId é obrigatório");

        RuleFor(x => x.Vendedor)
            .NotEmpty()
            .WithMessage("VendedorId é obrigatório");

    }
}