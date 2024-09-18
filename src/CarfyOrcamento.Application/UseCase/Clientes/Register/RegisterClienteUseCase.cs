using CarfyOrcamento.Communication.Request.Cliente;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using CarfyOrcamento.Communication.Response.Veiculo;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.Register;

public class RegisterClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public RegisterClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResponseJson<ResponseClienteShortJson>> Execute(RegisterClienteRequest request)
    {
        Validate(request);
        
        var cliente = new Cliente(
            request.NomeRazaoSocial,
            request.NomeFantasia,
            request.CpfCnpj,
            request.RgIe,
            request.Telefone,
            request.Email,
            request.ETipoPessoa,
            request.Observacao
        );

        await _clienteRepository.AddAsync(cliente);

        return new ResponseJson<ResponseClienteShortJson>(
            new ResponseClienteShortJson(
                cliente.Id,
                cliente.NomeRazaoSocial,
                cliente.Telefone,
                cliente.Email,
                cliente.TipoPessoa
            )
        );
    }
    
    private void Validate(RegisterClienteRequest request)
    {
        var validator = new RegisterClienteValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
        
    }
}
