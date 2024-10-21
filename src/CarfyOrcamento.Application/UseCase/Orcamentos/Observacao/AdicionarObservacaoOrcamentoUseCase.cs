using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;

public class AdicionarObservacaoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public AdicionarObservacaoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(AdicionarObservacaoOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.Observacao = request.Observacao;
        
        await _orcamentoRepository.UpdateAsync(orcamento);
    }
    
}