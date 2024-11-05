using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Catalogos;
using CarfyOrcamento.Core.Repositories.Catalogos;

namespace CarfyOrcamento.Application.UseCase.Catalogos.GetAll;

public class GetAllCatalogosUseCase
{
    private readonly ICatalogoRepository _catalogoRepository;
    
    public GetAllCatalogosUseCase(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public async Task<PagedResponse<ResponseCatalogoJson>> ExecuteAsync(int page, int pageSize)
    {
        var catalogos = await _catalogoRepository.GetAllAsync(page, pageSize);
        
        return new PagedResponse<ResponseCatalogoJson>( 
            catalogos.Data.Select(catalogo => new ResponseCatalogoJson(
                catalogo.Id,
                catalogo.Descricao,
                catalogo.Login,
                catalogo.Senha,
                catalogo.EnderecoSite,
                catalogo.Observacao,
                catalogo.CreatedAt,
                catalogo.UpdatedAt
            )).ToList(), catalogos.TotalCount,page, pageSize);
    }
    
}