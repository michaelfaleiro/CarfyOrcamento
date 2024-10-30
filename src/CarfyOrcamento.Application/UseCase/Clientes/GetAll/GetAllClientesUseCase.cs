using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Core.Repositories.Clientes;

namespace CarfyOrcamento.Application.UseCase.Clientes.GetAll;

public class GetAllClientesUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<PagedResponse<ResponseClienteShortJson>> ExecuteAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate , DateTime? endDate, string? search, string? sort)
    {
        var clientes = await _clienteRepository.GetAllClientesAsync(pageNumber, pageSize, status, startDate, endDate, search, sort);

        return new PagedResponse<ResponseClienteShortJson>(
            clientes.Data.Select(cliente => new ResponseClienteShortJson(
                cliente.Id,
                cliente.NomeRazaoSocial,
                cliente.Telefone,
                cliente.Email,
                cliente.TipoPessoa
            )), clientes.TotalCount, clientes.PageNumber, clientes.PageSize
        );
    }
}
