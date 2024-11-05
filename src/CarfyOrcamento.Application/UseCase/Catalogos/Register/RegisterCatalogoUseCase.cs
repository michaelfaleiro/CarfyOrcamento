using CarfyOrcamento.Communication.Request.Catalogo;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Catalogos;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Catalogos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Catalogos.Register;

public class RegisterCatalogoUseCase
{
    private readonly ICatalogoRepository _catalogoRepository;
    
    public RegisterCatalogoUseCase(ICatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public async Task<ResponseJson<ResponseCatalogoJson>> ExecuteAsync(RegisterCatalogoRequest request)
    {
        var catalogo = new Catalogo(request.Descricao,
            request.Login,
            request.Senha,
            request.EnderecoSite,
            request.Observacao);
        
        await _catalogoRepository.AddAsync(catalogo);
        
        return new ResponseJson<ResponseCatalogoJson>(new ResponseCatalogoJson(
            catalogo.Id,
            catalogo.Descricao,
            catalogo.Login,
            catalogo.Senha,
            catalogo.EnderecoSite,
            catalogo.Observacao,
            catalogo.CreatedAt,
            catalogo.UpdatedAt
        ));
    }
    
    private void Validator(RegisterCatalogoRequest request)
    {
        var validator = new RegisterCatalogoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}