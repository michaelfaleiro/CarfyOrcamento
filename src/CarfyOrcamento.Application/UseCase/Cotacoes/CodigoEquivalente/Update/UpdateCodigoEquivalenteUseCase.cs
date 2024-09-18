using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Update;

public class UpdateCodigoEquivalenteUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;
    
    public UpdateCodigoEquivalenteUseCase(ICotacaoRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }
    
    public async Task ExecuteAsync(UpdateCodigoEquivalenteRequest request)
    {
        Validate(request);
        
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId) 
                      ?? throw new NotFoundException("Cotação não encontrada");
        
        var item = cotacao.Itens.FirstOrDefault(i => i.Id == request.ItemId) 
                          ?? throw new NotFoundException("Item não encontrado");
       
        var codigoEquivalente = item.CodigoEquivalentes.FirstOrDefault(c => c.Id == request.Id) 
                                ?? throw new NotFoundException("Código equivalente não encontrado");
        
        codigoEquivalente.AtualizarCodigoEquivalente(
            request.Sku,
            request.FabricanteId,
            request.Fabricante,
            request.TipoProdutoEquivalente
        );
        
        await _cotacaoRepository.AtualizarCodigoEquivalente(codigoEquivalente);
    }
    
    private void Validate(UpdateCodigoEquivalenteRequest request)
    {
        var validator = new UpdateCodigoEquivalenteValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid) return;
        
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}