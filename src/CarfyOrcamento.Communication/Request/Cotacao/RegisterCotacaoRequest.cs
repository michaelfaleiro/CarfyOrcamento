using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Cotacao;
public record RegisterCotacaoRequest(Guid OrcamentoId, EStatusCotacao Status);

