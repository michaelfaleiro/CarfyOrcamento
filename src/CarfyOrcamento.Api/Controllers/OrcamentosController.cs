using CarfyOrcamento.Application.UseCase.Orcamentos.Desconto;
using CarfyOrcamento.Application.UseCase.Orcamentos.Frete;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetById;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.RemoverItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.Item.UpdateItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.AdicionarItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.RemoverItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.ItemAvulso.UpdateItemAvulso;
using CarfyOrcamento.Application.UseCase.Orcamentos.Observacao;
using CarfyOrcamento.Application.UseCase.Orcamentos.Register;
using CarfyOrcamento.Application.UseCase.Orcamentos.Status;
using CarfyOrcamento.Communication.Request.Orcamento;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Orcamentos;
using Microsoft.AspNetCore.Mvc;

namespace CarfyOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrcamentosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<ResponseOrcamentoShortJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(
        [FromBody] RegisterOrcamentoRequest request,
        [FromServices] RegisterOrcamentoUseCase useCase)
    {
        return Created(string.Empty, await useCase.ExecuteAsync(request));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseOrcamentoShortJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(
        [FromServices] GetAllOrcamentosUseCase useCase,
        [FromQuery] string? status,
        [FromQuery] string? orderBy,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
            )
    {
        return Ok(await useCase.ExecuteAsync(pageNumber, pageSize, status, orderBy));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseJson<ResponseOrcamentoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] GetByIdOrcamentoUseCase useCase)
    {
        return Ok(await useCase.ExecuteAsync(id));
    }
    
    [HttpPost("desconto")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDescontoAsync(
        [FromBody] AdicionarDescontoOrcamentoRequest request,
        [FromServices] DescontoOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPost("cupom")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCupomAsync(
        [FromBody] AdicionarCupomDescontoOrcamentoRequest orcamentoRequest,
        [FromServices] CupomDescontoUseCase useCase)
    {
        await useCase.ExecuteAsync(orcamentoRequest);
        return NoContent();
    }
    
    [HttpPost("frete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateFreteAsync(
        [FromBody] AdicionarFreteRequest request,
        [FromServices] FreteOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPut("status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStatusAsync(
        [FromBody] AlterarStatusOrcamentoRequest request,
        [FromServices] AlterarStatusOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPost("observacao")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarObservacaoAsync(
        [FromBody] AdicionarObservacaoOrcamentoRequest request,
        [FromServices] AdicionarObservacaoOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPost("observacao-interna")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarObservacaoInternaAsync(
        [FromBody] AdicionarObservacaoInternaOrcamentoRequest request,
        [FromServices] AdicionarObservacaoInternaOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPost("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarItemAsync(
        [FromBody] AdicionarItemOrcamentoRequest request,
        [FromServices] AdicionarItemOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPut("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItemAsync(
        [FromBody] UpdateItemOrcamentoRequest request,
        [FromServices] UpdateItemOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpDelete("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItemAsync(
        [FromBody] RemoverItemOrcamentoRequest request,
        [FromServices] RemoverItemOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPost("itens-avulsos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarItemAvulsoAsync(
        [FromBody] AdicionarItemAvulsoOrcamentoRequest request,
        [FromServices] AdicionarItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPut("itens-avulsos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItemAvulsoAsync(
        [FromBody] UpdateItemAvulsoOrcamentoRequest request,
        [FromServices] UpdateItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpDelete("itens-avulsos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItemAvulsoAsync(
        [FromBody] RemoverItemAvulsoOrcamentoRequest request,
        [FromServices] RemoverItemAvulsoOrcamentoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
}