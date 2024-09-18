using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Core.Repositories.Cotacoes;

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
        var cotacao = await _cotacaoRepository.GetByIdAsync(request.CotacaoId) 
                      ?? throw new Exception("Cotação não encontrada");
        
        cotacao.AlterarStatus(request.Status);
        
        await _cotacaoRepository.UpdateAsync(cotacao);
    }
}