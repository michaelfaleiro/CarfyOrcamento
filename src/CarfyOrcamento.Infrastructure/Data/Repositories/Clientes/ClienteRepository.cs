using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data.Repositories.Clientes;

public class ClienteRepository : IClienteRepository
{

    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AddAsync(Cliente entity)
    {
        await _context.Clientes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Cliente entity)
    {
        _context.Clientes.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<Cliente>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Clientes.AsNoTracking();

        var data = await query
            .OrderBy(x => x.NomeRazaoSocial)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Cliente>(data, count, pageNumber, pageSize);
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes
            .Include(x => x.Enderecos)
            .Include(x => x.Veiculos)
            .ThenInclude(x=> x.Veiculo)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Cliente entity)
    {
        _context.Clientes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarVeiculoAsync(ClienteVeiculos clienteVeiculos)
    {
        await _context.ClienteVeiculos.AddAsync(clienteVeiculos);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverVeiculoAsync(ClienteVeiculos clienteVeiculos)
    {
        _context.ClienteVeiculos.Remove(clienteVeiculos);
        await _context.SaveChangesAsync();
    }
}
