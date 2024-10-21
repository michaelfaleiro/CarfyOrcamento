using CarfyOrcamento.Application.UseCase.Veiculos.Register;
using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Veiculos.Update;

public class UpdateVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    
    public UpdateVeiculoUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task Execute(Guid id, RegisterVeiculoRequest request)
    {
        Validate(request);
        
        var veiculo = await _veiculoRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Veiculo não encontrado");
        
        veiculo.AtualizarVeiculo(new Veiculo(
            veiculo.Cliente,
            request.Placa,
            request.Chassi,
            request.Marca,
            request.Modelo,
            request.Cor,
            request.Ano,
            request.Motor
        ));
        
        await _veiculoRepository.UpdateAsync(veiculo);
    }
    
    private void Validate(RegisterVeiculoRequest request)
    {
        var validator = new RegisterVeiculoValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid) return;
        
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}