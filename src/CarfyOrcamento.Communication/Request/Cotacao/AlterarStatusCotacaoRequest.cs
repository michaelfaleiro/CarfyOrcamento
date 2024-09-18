using CarfyOrcamento.Core.Enums;

namespace CarfyOrcamento.Communication.Request.Cotacao;

public record AlterarStatusCotacaoRequest(Guid CotacaoId, EStatusCotacao Status);
