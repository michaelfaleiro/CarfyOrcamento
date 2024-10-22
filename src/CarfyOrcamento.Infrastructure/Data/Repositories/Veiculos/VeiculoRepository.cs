using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Veiculos;
using CarfyOrcamento.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data.Repositories.Veiculos;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;

    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Veiculo?> GetByIdAsync(Guid id)
    {
        return await _context
        .Veiculos
        .Include(x => x.Cliente)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Veiculo>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Veiculos.AsNoTracking();

        var data = await query
            .OrderBy(x => x.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Veiculo>(data, count, pageNumber, pageSize);
    }

    public async Task<Veiculo> AddAsync(Veiculo entity)
    {
        await _context.Veiculos.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(Veiculo entity)
    {
        _context.Veiculos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Veiculo entity)
    {
        _context.Veiculos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}