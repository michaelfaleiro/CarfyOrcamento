using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;

public class CupomDescontoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public CupomDescontoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(AdicionarCupomDescontoOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
                        ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.Cupom(request.CupomDesconto);
        
        await _orcamentoRepository.UpdateAsync(orcamento);
    }
}