using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data.Repositories.Orcamentos;

internal class OrcamentoRepository : IOrcamentoRepository
{
    private readonly AppDbContext _context;
    
    public OrcamentoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Orcamento?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Orcamentos
            .Include(x=> x.Itens)
            .Include(x=> x.ItensAvulsos)
            .FirstOrDefaultAsync(x=> x.Id == id);
        return entity;
    }

    public async Task<PagedResponse<Orcamento>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Orcamentos.AsNoTracking();
        
        var data = await query
            .OrderBy(x=> x.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var count = await query.CountAsync();
        
        return new PagedResponse<Orcamento>(data, count, pageNumber, pageSize);
    }

    public async Task<Orcamento> AddAsync(Orcamento entity)
    {
        await _context.Orcamentos.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Orcamento entity)
    {
        _context.Orcamentos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Orcamento entity)
    {
        _context.Orcamentos.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarItemAsync(ItemOrcamento item)
    {
        await _context.ItemOrcamentos.AddAsync(item);
        await _context.SaveChangesAsync();
    }
    
    public async Task RemoverItemAsync(ItemOrcamento item)
    {
        _context.ItemOrcamentos.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarItemAvulsoAsync(ItemAvulsoOrcamento item)
    {
        await _context.ItemAvulsoOrcamentos.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverItemAvulsoAsync(ItemAvulsoOrcamento item)
    {
        _context.ItemAvulsoOrcamentos.Remove(item);
        await _context.SaveChangesAsync();
    }
}