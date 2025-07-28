using Microsoft.AspNetCore.Mvc;
using MediatR;
using CRUD.Application.Commands.CreateCliente;
using CRUD.Application.Commands.UpdateCliente;
using CRUD.Application.Commands.DeleteCliente;
using CRUD.Application.Queries.GetClienteById;
using CRUD.Application.Queries.GetClientes;

namespace CRUD.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var query = new GetClientesQuery();
        var clientes = await _mediator.Send(query);
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var cliente = await _mediator.Send(new GetClienteByIdQuery(id));
        return cliente == null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateClienteCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateClienteCommand command)
    {
        if (id != command.Id) return BadRequest("ID da URL difere do corpo da requisição.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _mediator.Send(new DeleteClienteCommand(id));
        return NoContent();
    }
}
