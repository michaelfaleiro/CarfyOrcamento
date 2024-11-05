using CarfyOrcamento.Application.UseCase.Catalogos.Delete;
using CarfyOrcamento.Application.UseCase.Catalogos.GetAll;
using CarfyOrcamento.Application.UseCase.Catalogos.GetById;
using CarfyOrcamento.Application.UseCase.Catalogos.Register;
using CarfyOrcamento.Application.UseCase.Catalogos.Update;
using CarfyOrcamento.Communication.Request.Catalogo;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Catalogos;
using Microsoft.AspNetCore.Mvc;

namespace CarfyOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<ResponseCatalogoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCatalogoRequest request,
        [FromServices] RegisterCatalogoUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseCatalogoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllCatalogosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.ExecuteAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseJson<ResponseCatalogoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid id,
        [FromServices] GetByIdCatalogoUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCatalogoRequest request,
        [FromServices] UpdateCatalogoUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteCatalogoUseCase useCase)
    {
        await useCase.ExecuteAsync(id);
        return NoContent();
    }
}