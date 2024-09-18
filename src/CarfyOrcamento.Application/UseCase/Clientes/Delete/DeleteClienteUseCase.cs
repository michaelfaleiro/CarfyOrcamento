using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.Delete;

public class DeleteClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Execute(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente não encontrado");

        await _clienteRepository.DeleteAsync(cliente);
    }
}
