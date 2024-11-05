using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Catalogos;
using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Catalogos.GetById;

public class GetByIdCatalogoUseCase
{
    private readonly ICatalogoRepository _catalogoRepository;
    
    public GetByIdCatalogoUseCase(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public async Task<ResponseJson<ResponseCatalogoJson>> ExecuteAsync(Guid id)
    {
        var catalogo = await _catalogoRepository.GetByIdAsync(id) 
            ?? throw new NotFoundException("Catalogo não encontrado");
        
        var result = new ResponseCatalogoJson(
            catalogo.Id,
            catalogo.Descricao,
            catalogo.Login,
            catalogo.Senha,
            catalogo.EnderecoSite,
            catalogo.Observacao,
            catalogo.CreatedAt,
            catalogo.UpdatedAt);
        
        return new ResponseJson<ResponseCatalogoJson>(result);
    }
}