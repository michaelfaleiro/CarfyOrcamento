
using CarfyOrcamento.Application.UseCase.Orcamentos.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetAll;
using CarfyOrcamento.Application.UseCase.Orcamentos.GetById;
using CarfyOrcamento.Application.UseCase.Orcamentos.Register;
using CarfyOrcamento.Application.UseCase.Orcamentos.RemoverItem;
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
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        return Ok(await useCase.ExecuteAsync(pageNumber, pageSize));
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
    
    [HttpPost("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostItemAsync(
        [FromBody] AdicionarItemOrcamentoRequest request,
        [FromServices] AdicionarItemOrcamentoUseCase useCase)
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
    
}