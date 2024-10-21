using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.GetById;

public class GetByIdClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetByIdClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseJson<ResponseClienteJson>> Execute(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente não encontrado");

        return new ResponseJson<ResponseClienteJson>(new ResponseClienteJson(
            cliente.Id,
            cliente.NomeRazaoSocial,
            cliente.NomeFantasia,
            cliente.CpfCnpj,
            cliente.RgIe,
            cliente.Telefone,
            cliente.Email,
            cliente.Veiculos.Select(veiculo => new ResponseVeiculoJson(
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
            )).ToList(),
            cliente.TipoPessoa,
            cliente.Observacao,
            cliente.CreatedAt,
            cliente.UpdatedAt
       ));
    }
}
