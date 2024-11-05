using CarfyOrcamento.Communication.Request.Catalogo;
using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Catalogos.Update;

public class UpdateCatalogoUseCase
{
    private readonly ICatalogoRepository _catalogoRepository;
    
    public UpdateCatalogoUseCase(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public async Task ExecuteAsync(UpdateCatalogoRequest request)
    {
        var catalogo = await _catalogoRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException("Catalogo não encontrado");
        
        catalogo.Update(request.Descricao, request.Login, request.Senha, request.EnderecoSite, request.Observacao);
        
        await _catalogoRepository.UpdateAsync(catalogo);
    }
}