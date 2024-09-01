using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data.Repositories.Cotacoes;

internal class CotacaoRepository : ICotacaoRepository
{
    private readonly AppDbContext _context;

    public CotacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cotacao?> GetByIdAsync(Guid id)
    {
        return await _context.Cotacoes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Cotacao>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Cotacoes.AsNoTracking();

        var data = await query
            .OrderBy(x => x.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Cotacao>(data, count, pageNumber, pageSize);
    }

    public async Task<Cotacao> AddAsync(Cotacao entity)
    {
        await _context.Cotacoes.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }

    public async Task UpdateAsync(Cotacao entity)
    {
        _context.Cotacoes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cotacao entity)
    {
        _context.Cotacoes.Remove(entity);
        await _context.SaveChangesAsync();
    }
}