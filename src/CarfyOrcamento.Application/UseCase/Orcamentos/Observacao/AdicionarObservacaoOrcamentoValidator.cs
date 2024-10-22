using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarfyOrcamento.Communication.Request.Orcamento;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;

public class AdicionarObservacaoOrcamentoValidator : AbstractValidator<AdicionarObservacaoOrcamentoRequest>
{
    public AdicionarObservacaoOrcamentoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.Observacao)
            .NotEmpty()
            .WithMessage("Observacao é obrigatório");
    }

}