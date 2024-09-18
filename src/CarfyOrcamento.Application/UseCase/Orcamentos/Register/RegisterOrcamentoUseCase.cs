using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Orcamentos;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Core.Repositories.Orcamentos;
using CarfyOrcamento.Exceptions.ExceptionsBase;
using FluentValidation;

namespace CarfyOrcamento.Application.UseCase.Orcamentos.Register;

public class RegisterOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IClienteRepository _clienteRepository;

    public RegisterOrcamentoUseCase(IOrcamentoRepository orcamentoRepository, IClienteRepository clienteRepository)
    {
        _orcamentoRepository = orcamentoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseJson<ResponseOrcamentoShortJson>> ExecuteAsync(RegisterOrcamentoRequest request)
    {
        Validate(request);

        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
                      ?? throw new NotFoundException("Cliente não encontrado");
        
        var veiculo = cliente.Veiculos.FirstOrDefault(x => x.Veiculo.Id == request.VeiculoId)
                      ?? throw new NotFoundException("Veículo não encontrado");
        
        var entity = new Orcamento(
            cliente,
            veiculo.Veiculo,
            request.Vendedor,
            request.Status
        );

        var orcamento = await _orcamentoRepository.AddAsync(entity);

        var result = new ResponseOrcamentoShortJson(
            orcamento.Id, new ResponseClienteShortJson(
                cliente.Id, cliente.NomeRazaoSocial, cliente.Telefone, cliente.Email, cliente.TipoPessoa), 
            new ResponseVeiculoShortJson(veiculo.Veiculo.Id, veiculo.Veiculo.Placa, 
                veiculo.Veiculo.Modelo, veiculo.Veiculo.Chassi)
            ,orcamento.Vendedor, orcamento.Status, orcamento.CreatedAt, orcamento.UpdatedAt);

        return new ResponseJson<ResponseOrcamentoShortJson>(result);
    }

    private void Validate(RegisterOrcamentoRequest request)
    {
        var validator = new RegisterOrcamentoValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}