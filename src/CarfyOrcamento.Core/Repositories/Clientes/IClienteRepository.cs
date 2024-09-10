using CarfyOrcamento.Core.Entities;

namespace CarfyOrcamento.Core.Repositories.Clientes;

public interface IClienteRepository : IRepository<Cliente>
{
    Task AdicionarVeiculoAsync(ClienteVeiculos clienteVeiculos);
    Task RemoverVeiculoAsync(ClienteVeiculos clienteVeiculos);
}
