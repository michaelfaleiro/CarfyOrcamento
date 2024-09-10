using CarfyOrcamento.Communication.Request.Veiculo;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Veiculos.Register;

public class RegisterVeiculoValidator : AbstractValidator<RegisterVeiculoRequest>
{
    public RegisterVeiculoValidator()
    {
        RuleFor(x => x.Marca)
            .NotEmpty().WithMessage("Marca é obrigatório")
            .MaximumLength(100).WithMessage("Marca deve ter no máximo 100 caracteres");

        RuleFor(x => x.Modelo)
            .NotEmpty().WithMessage("Modelo é obrigatório")
            .MaximumLength(100).WithMessage("Modelo deve ter no máximo 100 caracteres");
        
        RuleFor(x => x.Placa)
            .NotEmpty().WithMessage("Placa é obrigatório")
            .MaximumLength(7).WithMessage("Placa deve ter no máximo 7 caracteres");

        RuleFor(x => x.Cor)
            .NotEmpty().When(x => !string.IsNullOrEmpty(x.Cor))
            .WithMessage("Cor é obrigatório")
            .MaximumLength(20).WithMessage("Cor deve ter no máximo 20 caracteres");

        
    }
    
}