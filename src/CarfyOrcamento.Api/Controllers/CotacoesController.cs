using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.AdicionarCodigoEquivalente;
using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Delete;
using CarfyOrcamento.Application.UseCase.Cotacoes.CodigoEquivalente.Update;
using CarfyOrcamento.Application.UseCase.Cotacoes.GetAll;
using CarfyOrcamento.Application.UseCase.Cotacoes.GetById;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.AdicionarItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.GetById;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.RemoverItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Item.UpdateItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.AdicionarPrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.RemoverPrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.PrecoItem.UpdatePrecoItem;
using CarfyOrcamento.Application.UseCase.Cotacoes.Register;
using CarfyOrcamento.Application.UseCase.Cotacoes.Status;
using CarfyOrcamento.Communication.Request.Cotacao;
using CarfyOrcamento.Communication.Request.Cotacao.CodigoEquivalente;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Cotacoes;
using CarfyOrcamento.Communication.Response.ItemCotacao;
using Microsoft.AspNetCore.Mvc;

namespace CarfyOrcamento.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CotacoesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<ResponseCotacaoShortJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterCotacao(
        [FromServices] RegisterCotacaoUseCase useCase,
        [FromBody] RegisterCotacaoRequest request)
    {
        var response = await useCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseCotacaoShortJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCotacoes(
        [FromServices] GetAllCotacoesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.ExecuteAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseJson<ResponseCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdCotacao(
        [FromServices] GetByIdCotacaoUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPut("status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AlterarStatusCotacao(
        [FromServices] AlterarStatusCotacaoUseCase useCase,
        [FromBody] AlterarStatusCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpGet("itens/{id:guid}")]
    [ProducesResponseType(typeof(ResponseJson<ResponseItemCotacaoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItemCotacaoById(
        [FromServices] GetItemCotacaoByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpPost("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarItemCotacao(
        [FromServices] AdicionarItemCotacaoUseCase useCase,
        [FromBody] AdicionarItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpPut("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateItemCotacao(
        [FromServices] UpdateItemCotacaoUseCase useCase,
        [FromBody] UpdateItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpDelete("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverItemCotacao(
        [FromServices] RemoverItemCotacaoUseCase useCase,
        [FromBody] RemoverItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }


    [HttpPost("precos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarPrecoItemCotacao(
        [FromServices] AdicionarPrecoItemCotacaoUseCase useCase,
        [FromBody] AdicionarPrecoItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpPut("precos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePrecoItemCotacao(
        [FromServices] UpdatePrecoItemCotacaoUseCase useCase,
        [FromBody] UpdatePrecoItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpDelete("precos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverPrecoItemCotacao(
        [FromServices] RemoverPrecoItemCotacaoUseCase useCase,
        [FromBody] RemoverPrecoItemCotacaoRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpPost("codigo-equivalentes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarCodigoEquivalentes(
        [FromServices] AdicionarCodigoEquivalenteUseCase useCase,
        [FromBody] AdicionarCodigoEquivalenteRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpPut("codigo-equivalentes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCodigoEquivalentes(
        [FromServices] UpdateCodigoEquivalenteUseCase useCase,
        [FromBody] UpdateCodigoEquivalenteRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpDelete("codigo-equivalentes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverCodigoEquivalentes(
        [FromServices] RemoverCodigoEquivalenteUseCase useCase,
        [FromBody] RemoverCodigoEquivalenteRequest request)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

}


