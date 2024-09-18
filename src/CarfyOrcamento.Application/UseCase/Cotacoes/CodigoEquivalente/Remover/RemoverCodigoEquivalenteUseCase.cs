using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Delete;

public class RemoverCodigoEquivalenteUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;
    
    public RemoverCodigoEquivalenteUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }
    
    public async Task ExecuteAsync(RemoverCodigoEquivalenteRequest request)
    {
        Validate(request);
        
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId) 
                      ?? throw new NotFoundException("Cotação não encontrada");
        
        var item = cotacao.Itens.FirstOrDefault(i => i.Id == request.ItemId) 
                          ?? throw new NotFoundException("Item não encontrado");
       
        var codigoEquivalente = item.CodigoEquivalentes.FirstOrDefault(c => c.Id == request.Id) 
                                ?? throw new NotFoundException("Código equivalente não encontrado");
        
        item.CodigoEquivalentes.Remove(codigoEquivalente);
        
        await _cotacaoRepository.RemoverCodigoEquivalente(codigoEquivalente);
        
    }
    
    private void Validate(RemoverCodigoEquivalenteRequest request)
    {
        var validator = new RemoverCodigoEquivalenteValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid) return;
        
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}