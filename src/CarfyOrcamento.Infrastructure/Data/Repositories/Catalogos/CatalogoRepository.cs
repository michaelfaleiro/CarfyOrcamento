using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace CarfyOrcamento.Infrastructure.Data.Repositories.Catalogos;

public class CatalogoRepository : ICatalogoRepository
{
    private readonly AppDbContext _context;
    
    public CatalogoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Catalogo?> GetByIdAsync(Guid id)
    {
        var catalogo = await _context.Catalogos.FirstOrDefaultAsync(x=> x.Id == id);
        return catalogo;
    }

    public async Task<PagedResponse<Catalogo>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Catalogos.AsNoTracking();

        var data = await query
            .OrderBy(x => x.Descricao)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Catalogo>(data, count, pageNumber, pageSize);
    }

    public async Task<Catalogo> AddAsync(Catalogo entity)
    {
        await _context.Catalogos.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Catalogo entity)
    {
        _context.Catalogos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Catalogo entity)
    {
        _context.Catalogos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}