using CarfyOrcamento.Communication.Request.Catalogo;
using CarfyOrcamento.Core.Entities;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Catalogos.Register;

public class RegisterCatalogoValidator : AbstractValidator<RegisterCatalogoRequest>
{
    public RegisterCatalogoValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Login é obrigatório");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("Senha é obrigatória");
    }
}