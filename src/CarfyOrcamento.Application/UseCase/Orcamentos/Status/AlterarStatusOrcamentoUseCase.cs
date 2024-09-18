using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Enums;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Status;
public class AlterarStatusOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AlterarStatusOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task ExecuteAsync(AlterarStatusOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Orçamento não encontrado");
        
        orcamento.AlterarStatus((EStatusOrcamento)request.Status);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }
}
