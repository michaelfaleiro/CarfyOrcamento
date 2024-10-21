using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;

public class AdicionarObservacaoInternaOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public AdicionarObservacaoInternaOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(AdicionarObservacaoInternaOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.ObservacaoInterna = request.ObservacaoInterna;
        
        await _orcamentoRepository.UpdateAsync(orcamento);
    }
    
}