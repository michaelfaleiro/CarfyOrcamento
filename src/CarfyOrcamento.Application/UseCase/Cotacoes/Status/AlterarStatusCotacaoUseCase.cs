using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Status;

public class AlterarStatusCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;
    
    public AlterarStatusCotacaoUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }
    
    public async Task ExecuteAsync(AlterarStatusCotacaoRequest request)
    {
        ValidateRequest(request);
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId) 
                      ?? throw new Exception("Cotação não encontrada");
        
        cotacao.AlterarStatus(request.Status);
        
        await _cotacaoRepository.UpdateAsync(cotacao);
    }
    
    private void ValidateRequest(AlterarStatusCotacaoRequest request)
    {
        var validator = new AlterarStatusCotacaoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid) return;
        
        var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            
        throw new ErrorOnValidateException(errors);
        
    }
}