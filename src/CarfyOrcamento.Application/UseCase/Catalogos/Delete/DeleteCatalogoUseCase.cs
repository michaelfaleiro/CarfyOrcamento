using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Catalogos.Delete;

public class DeleteCatalogoUseCase
{
    private readonly ICatalogoRepository _catalogoRepository;
    
    public DeleteCatalogoUseCase(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public async Task ExecuteAsync(Guid id)
    {
        var catalogo = await _catalogoRepository.GetByIdAsync(id) 
            ?? throw new NotFoundException("Catalogo não encontrado");
        
        await _catalogoRepository.DeleteAsync(catalogo);
    }
}