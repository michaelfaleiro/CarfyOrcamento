using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Cotacoes;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Cotacoes;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Cotacoes.Register;
public class RegisterCotacaoUseCase
{
    private readonly ICotacaoRepository _cotacaoRepository;
    private readonly IOrcamentoRepository _orcamentoRepository;

    public RegisterCotacaoUseCase(ICotacaoRepository cotacaoRepository, IOrcamentoRepository orcamentoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task<ResponseJson<ResponseCotacaoShortJson>> ExecuteAsync(RegisterCotacaoRequest request)
    {
        Validate(request);
        
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId) 
            ?? throw new NotFoundException("Orçamento não encontrado");

        var cotacao = new Cotacao(orcamento, request.Status);

        await _cotacaoRepository.AddAsync(cotacao);

        var result = new ResponseCotacaoShortJson(
            cotacao.Id, cotacao.Orcamento.Id,cotacao.Status, cotacao.CreatedAt, cotacao.UpdatedAt);

        return new ResponseJson<ResponseCotacaoShortJson>(result);
    }

    private void Validate(RegisterCotacaoRequest request)
    {
        var validator = new RegisterCotacaoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
