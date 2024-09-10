using CarfyOrcamento.Application.UseCase.Clientes.Register;
using CarfyOrcamento.Communication.Request.Cliente;
using CarfyOrcamento.Core.Entities;
using CarfyOrcamento.Core.Repositories.Clientes;
using CarfyOrcamento.Exceptions.ExceptionsBase;

namespace CarfyOrcamento.Application.UseCase.Clientes.Update;

public class UpdateClietnteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClietnteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Execute(Guid id, RegisterClienteRequest request)
    {
        Validate(request);
        
        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente não encontrado");

        cliente.AtualizarCliente(new Cliente(
            request.NomeRazaoSocial,
            request.NomeFantasia,
            request.CpfCnpj,
            request.RgIe,
            request.Telefone,
            request.Email,
            request.ETipoPessoa,
            request.Observacao
        ));

        await _clienteRepository.UpdateAsync(cliente);
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
