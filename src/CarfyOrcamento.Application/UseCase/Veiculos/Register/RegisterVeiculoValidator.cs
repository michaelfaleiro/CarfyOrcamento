using CarfyOrcamento.Communication.Request.Veiculo;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Veiculos.Register;

public class RegisterVeiculoValidator : AbstractValidator<RegisterVeiculoRequest>
{
    public RegisterVeiculoValidator()
    {
        RuleFor(x => x.Marca)
            .NotEmpty().WithMessage("Marca é obrigatório")
            .MaximumLength(100)
            .WithMessage("Marca deve ter no máximo 100 caracteres");

        RuleFor(x => x.Modelo)
            .NotEmpty().WithMessage("Modelo é obrigatório")
            .MaximumLength(100)
            .WithMessage("Modelo deve ter no máximo 100 caracteres");

        RuleFor(x => x.Placa)
            .Must(chassi => string.IsNullOrEmpty(chassi) || chassi.Length == 7)
            .WithMessage("Placa deve ter 7 caracteres");

        RuleFor(x => x.Ano)
            .NotEmpty().WithMessage("Ano é obrigatório")
            .GreaterThan(1900).WithMessage("Ano deve ser maior que 1900")
            .LessThan(2100).WithMessage("Ano deve ser menor que 2100");

        RuleFor(x => x.Chassi)
            .Must(chassi => string.IsNullOrEmpty(chassi) || chassi.Length == 17)
            .WithMessage("Chassi deve ter 17 caracteres");

    }

}