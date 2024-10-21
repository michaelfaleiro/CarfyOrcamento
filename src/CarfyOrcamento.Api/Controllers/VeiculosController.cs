using CarfyOrcamento.Application.UseCase.Veiculos.Delete;
using CarfyOrcamento.Application.UseCase.Veiculos.GetAll;
using CarfyOrcamento.Application.UseCase.Veiculos.GetById;
using CarfyOrcamento.Application.UseCase.Veiculos.Register;
using CarfyOrcamento.Application.UseCase.Veiculos.Update;
using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace CarfyOrcamento.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<ResponseVeiculoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseJson<ResponseVeiculoJson>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(
        [FromBody] RegisterVeiculoRequest request,
        [FromServices] RegisterVeiculoUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseVeiculoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllVeiculosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ResponseJson<ResponseVeiculoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid id,
        [FromServices] GetByIdVeiculoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] RegisterVeiculoRequest request,
        [FromServices] UpdateVeiculoUseCase useCase)
    {
        await useCase.Execute(id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteVeiculoUseCase useCase)
    {
        await useCase.Execute(id);
        return NoContent();
    }

}