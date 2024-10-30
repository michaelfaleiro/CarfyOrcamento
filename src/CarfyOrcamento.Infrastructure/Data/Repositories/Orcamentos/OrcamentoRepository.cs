using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Enums;
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
            .Include(x => x.Cliente)
            .Include(x => x.Veiculo)
            .Include(x => x.Itens)
            .Include(x => x.ItensAvulsos)
            .Include(x => x.Cotacoes)
            .FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public async Task<PagedResponse<Orcamento>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Orcamentos
            .AsNoTracking()
            .Include(x => x.Cliente)
            .Include(x => x.Veiculo);


        var data = await query
            .OrderBy(x => x.CreatedAt)
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

    public async Task<PagedResponse<Orcamento>> GetAllAsync(
        int pageNumber, int pageSize, string? status, DateTime? startDate = null,
        DateTime? endDate = null, string? search = null, string? vendedor = null, string? orderBy = null)
{
    IQueryable<Orcamento> query = _context.Orcamentos
        .AsNoTracking()
        .Include(x => x.Cliente)
        .Include(x => x.Veiculo);

    if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<EStatusOrcamento>(status, out var statusEnum))
    {
        query = query.Where(x => x.Status == statusEnum);
    }

    if (startDate.HasValue)
    {
        var startDateOnly = startDate.Value.Date;
        query = query.Where(x => x.CreatedAt.Date >= startDateOnly);
    }

    if (endDate.HasValue)
    {
        var endDateOnly = endDate.Value.Date;
        query = query.Where(x => x.CreatedAt.Date <= endDateOnly);
    }

    if (!string.IsNullOrWhiteSpace(search))
    {
        query = query.Where(x => EF.Functions.ILike(x.Cliente.NomeRazaoSocial, $"%{search}%"));
    }
    
    if (!string.IsNullOrWhiteSpace(vendedor))
    {
        query = query.Where(x => EF.Functions.ILike(x.Vendedor, $"%{vendedor}%"));
    }
    
    if (!string.IsNullOrWhiteSpace(orderBy))
    {
        query = orderBy switch
        {
            "CreatedAt" => query.OrderBy(x => x.CreatedAt),
            "CreatedAtDesc" => query.OrderByDescending(x => x.CreatedAt),
            "UpdatedAt" => query.OrderBy(x => x.UpdatedAt),
            "UpdatedAtDesc" => query.OrderByDescending(x => x.UpdatedAt),
            _ => query.OrderByDescending(x => x.CreatedAt) // Default sorting
        };
    }
    else
    {
        query = query.OrderByDescending(x => x.CreatedAt); // Default sorting
    }

    var data = await query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var count = await query.CountAsync();

    return new PagedResponse<Orcamento>(data, count, pageNumber, pageSize);
}

    public async Task AdicionarItemAsync(ItemOrcamento item)
    {
        await _context.ItemOrcamentos.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarItemAsync(ItemOrcamento item)
    {
        _context.ItemOrcamentos.Update(item);
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

    public async Task AtualizarItemAvulsoAsync(ItemAvulsoOrcamento item)
    {
        _context.ItemAvulsoOrcamentos.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverItemAvulsoAsync(ItemAvulsoOrcamento item)
    {
        _context.ItemAvulsoOrcamentos.Remove(item);
        await _context.SaveChangesAsync();
    }
}