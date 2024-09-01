using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Register;

public class RegisterOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public RegisterOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task<ResponseJson<ResponseOrcamentoShortJson>> ExecuteAsync(RegisterOrcamentoRequest request)
    {
        Validate(request);

        var entity = new Orcamento(
            request.ClienteId,
            request.VeiculoId,
            request.VendedorId
        );
        
        var orcamento = await _orcamentoRepository.AddAsync(entity);
        
        var result = new ResponseOrcamentoShortJson(
            orcamento.Id, orcamento.ClienteId,
            orcamento.VeiculoId, orcamento.VendedorId,
            orcamento.CreatedAt, orcamento.UpdatedAt);
        
        return new ResponseJson<ResponseOrcamentoShortJson>(result);
    }
    
    private void Validate(RegisterOrcamentoRequest request)
    {
        var validator = new RegisterOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}