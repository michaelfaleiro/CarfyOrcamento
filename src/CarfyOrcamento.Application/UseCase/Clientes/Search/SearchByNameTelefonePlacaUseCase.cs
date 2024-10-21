using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Repositories.Clientes;

namespace CarfyOrcamento.Application.UseCase.Clientes.Search;

public class SearchByNameTelefonePlacaUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public SearchByNameTelefonePlacaUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<PagedResponse<ResponseClienteJson>> Execute(string search, int pageNumber, int pageSize)
    {
        var pagedClientes = await _clienteRepository.SearchAsync(search, pageNumber, pageSize);

        var responseClientes = pagedClientes.Data.Select(cliente => new ResponseClienteJson(
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
            cliente.UpdatedAt ?? default
        )).ToList();

        return new PagedResponse<ResponseClienteJson>(responseClientes, pagedClientes.TotalCount, pageNumber, pageSize);
    }
}