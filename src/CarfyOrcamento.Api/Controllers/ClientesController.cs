using CarfyOrcamento.Application.UseCase.Clientes.Delete;
using CarfyOrcamento.Application.UseCase.Clientes.GetAll;
using CarfyOrcamento.Application.UseCase.Clientes.GetById;
using CarfyOrcamento.Application.UseCase.Clientes.Register;
using CarfyOrcamento.Application.UseCase.Clientes.Search;
using CarfyOrcamento.Application.UseCase.Clientes.Update;
using CarfyOrcamento.Application.UseCase.Clientes.Veiculos;
using CarfyOrcamento.Communication.Request.Cliente;
using CarfyOrcamento.Communication.Request.Veiculo;
using CarfyOrcamento.Communication.Response;
using CarfyOrcamento.Communication.Response.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace CarfyOrcamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseJson<ResponseClienteShortJson>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RegisterClienteRequest request,
            [FromServices] RegisterClienteUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<ResponseClienteShortJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] GetAllClientesUseCase useCase,
            [FromQuery] string? status,
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var response = await useCase.ExecuteAsync(pageNumber, pageSize, status, startDate, endDate, search, sort);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseJson<ResponseClienteJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            [FromServices] GetByIdClienteUseCase useCase)
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] RegisterClienteRequest request,
            [FromServices] UpdateClietnteUseCase useCase)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] DeleteClienteUseCase useCase)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPost("veiculos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarVeiculo(
            [FromBody] AdicionarVeiculoRequest request,
            [FromServices] AdicionarVeiculoClienteUseCase useCase)
        {
            await useCase.AdicionarVeiculoAsync(request);
            return NoContent();
        }

        [HttpDelete("veiculos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverVeiculo(
            [FromBody] RemoverVeiculoRequest request,
            [FromServices] RemoverVeiculoClienteUseCase useCase)
        {
            await useCase.RemoverVeiculoAsync(request);
            return NoContent();
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(PagedResponse<ResponseClienteShortJson>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(
            [FromQuery] string search,
            [FromServices] SearchByNameTelefonePlacaUseCase useCase,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var response = await useCase.Execute(search, pageNumber, pageSize);
            return Ok(response);
        }
    }
}
