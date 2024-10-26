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
        return await _context.Cotacoes.AsSplitQuery()
            .Include(x => x.Orcamento)
            .Include(x => x.Itens)
            .ThenInclude(x => x.PrecoItemFornecedor)
            .Include(x => x.Itens)
            .ThenInclude(x => x.CodigoEquivalentes)
            .Include(x => x.Orcamento)
            .ThenInclude(x => x.Veiculo)
            .ThenInclude(x=> x.Cliente)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Cotacao>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Cotacoes
            .AsNoTracking();

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

    public Task AdicionarItemCotacao(ItemCotacao itemCotacao)
    {
        _context.ItemCotacoes.Add(itemCotacao);
        return _context.SaveChangesAsync();
    }

    public Task AtualizarItemCotacao(ItemCotacao itemCotacao)
    {
        _context.ItemCotacoes.Update(itemCotacao);
        return _context.SaveChangesAsync();

    }

    public Task RemoverItemCotacao(ItemCotacao itemCotacao)
    {
        _context.ItemCotacoes.Remove(itemCotacao);
        return _context.SaveChangesAsync();

    }

    public async Task AdicionarPrecoItemCotacao(PrecoItemCotacao precoItemCotacao)
    {
        _context.PrecoItemCotacoes.Add(precoItemCotacao);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarPrecoItemCotacao(PrecoItemCotacao precoItemCotacao)
    {
        _context.PrecoItemCotacoes.Update(precoItemCotacao);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverPrecoItemCotacao(PrecoItemCotacao precoItemCotacao)
    {
        _context.PrecoItemCotacoes.Remove(precoItemCotacao);
        await _context.SaveChangesAsync();
    }

    public async Task AdicionarCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente)
    {
        _context.CodigoEquivalentes.Add(itemCodigoEquivalente);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente)
    {
        _context.CodigoEquivalentes.Update(itemCodigoEquivalente);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverCodigoEquivalente(ItemCodigoEquivalente itemCodigoEquivalente)
    {
        _context.CodigoEquivalentes.Remove(itemCodigoEquivalente);
        await _context.SaveChangesAsync();
    }

    public async Task<ItemCotacao?> GetItemById(Guid itemId)
    {
        return await _context.ItemCotacoes
            .Include(x => x.Cotacao)
            .Include(x => x.CodigoEquivalentes)
            .Include(x => x.PrecoItemFornecedor)
            .FirstOrDefaultAsync(x => x.Id == itemId);
    }
}