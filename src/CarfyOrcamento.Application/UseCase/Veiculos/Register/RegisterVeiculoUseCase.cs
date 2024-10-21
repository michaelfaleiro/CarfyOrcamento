using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Veiculos.Register;

public class RegisterVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IClienteRepository _clienteRepository;

    public RegisterVeiculoUseCase(IVeiculoRepository veiculoRepository, IClienteRepository clienteRepository)
    {
        _veiculoRepository = veiculoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseJson<ResponseVeiculoJson>> Execute(RegisterVeiculoRequest request)
    {
        Validate(request);

        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
            ?? throw new NotFoundException("Cliente não encontrado");
        
        var veiculo = new Veiculo(
            cliente,
            request.Placa,
            request.Chassi,
            request.Marca,
            request.Modelo,
            request.Cor,
            request.Ano,
            request.Motor
        );

        await _veiculoRepository.AddAsync(veiculo);

        return new ResponseJson<ResponseVeiculoJson>(
            new ResponseVeiculoJson(
                veiculo.Id,
                veiculo.Placa,
                veiculo.Chassi,
                veiculo.Marca,
                veiculo.Modelo,
                veiculo.Cor,
                veiculo.Ano,
                veiculo.Motor,
                veiculo.CreatedAt,
                veiculo.UpdatedAt
            )
        );
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