using CarfyOrcamento.Communication.Request.Cliente;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Clientes.Register;

public class RegisterClienteValidator : AbstractValidator<RegisterClienteRequest>
{
    public RegisterClienteValidator()
    {
        RuleFor(x => x.NomeRazaoSocial)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

        RuleFor(x => x.Email)
            .MaximumLength(100).WithMessage("Email deve ter no máximo 100 caracteres")
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Email inválido");

        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("Telefone é obrigatório")
            .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres");
        
        RuleFor(x => x.CpfCnpj)
            .Length(11, 14).When(x => !string.IsNullOrEmpty(x.CpfCnpj))
            .WithMessage("CpfCnpj deve ter entre 11 e 14 caracteres");
     
        RuleFor(x => x.ETipoPessoa)
            .IsInEnum().WithMessage("Tipo de pessoa é obrigatório e deve ser um valor válido.");
    }

}