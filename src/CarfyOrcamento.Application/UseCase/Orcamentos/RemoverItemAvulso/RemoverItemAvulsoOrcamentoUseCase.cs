using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.RemoverItemAvulso;

public class RemoverItemAvulsoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    
    public RemoverItemAvulsoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }
    
    public async Task ExecuteAsync(RemoverItemAvulsoOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
                        ?? throw new Exception("Orcamento não encontrado");
        
        var item = orcamento.ItensAvulsos.FirstOrDefault(i => i.Id == request.ItemAvulsoId)
                   ?? throw new Exception("Item avulso não encontrado");
        
        
        await _orcamentoRepository.RemoverItemAvulsoAsync(item);
    }
    
    private void Validate(RemoverItemAvulsoOrcamentoRequest request)
    {
        var validator = new RemoverItemAvulsoOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errors = result.Errors.Select(x=> x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}