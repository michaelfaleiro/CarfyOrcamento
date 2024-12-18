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
            .Include(x=> x.Orcamentos)
            .Include(x => x.Enderecos)
            .Include(x => x.Veiculos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Cliente entity)
    {
        _context.Clientes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarVeiculoAsync(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverVeiculoAsync(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<Cliente>> SearchAsync(string search, int pageNumber, int pageSize)
{
    var query = _context.Clientes.AsNoTracking()
        .Include(c => c.Veiculos);

    var totalItems = await query
        .Where(c => EF.Functions.ILike(c.NomeRazaoSocial, $"%{search}%")
                    || EF.Functions.ILike(c.Telefone, $"%{search}%")
                    || c.Veiculos.Any(cv => EF.Functions.ILike(cv.Placa, $"%{search}%")))
        .CountAsync();

    var clientes = await query
        .Where(c => EF.Functions.ILike(c.NomeRazaoSocial, $"%{search}%")
                    || EF.Functions.ILike(c.Telefone, $"%{search}%")
                    || c.Veiculos.Any(cv => EF.Functions.ILike(cv.Placa, $"%{search}%")))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return new PagedResponse<Cliente>(clientes, totalItems, pageNumber, pageSize);
}

    public async Task<PagedResponse<Cliente>> GetAllClientesAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate = null,
        DateTime? endDate = null, string? search = null, string? orderBy = null)
    {
        IQueryable<Cliente> query = _context.Clientes.AsNoTracking()
            .Include(c => c.Veiculos);
        
        if (startDate.HasValue)
        {
            query = query.Where(c => c.CreatedAt >= startDate);
        }

        if (endDate.HasValue)
        {
            query = query.Where(c => c.CreatedAt <= endDate);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => EF.Functions.ILike(c.NomeRazaoSocial, $"%{search}%")
                                     || EF.Functions.ILike(c.Telefone, $"%{search}%")
                                     || c.Veiculos.Any(cv => EF.Functions.ILike(cv.Placa, $"%{search}%")));
        }

        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            query = orderBy switch
            {
                "nome" => query.OrderBy(c => c.NomeRazaoSocial),
                "telefone" => query.OrderBy(c => c.Telefone),
                "dataCadastro" => query.OrderBy(c => c.CreatedAt),
                _ => query.OrderBy(c => c.NomeRazaoSocial)
            };
        }

        var totalCount = await query.CountAsync();

        var clientes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResponse<Cliente>(clientes, totalCount, pageNumber, pageSize);
    }
}
