using CRUD.Application.Queries.GetClienteById;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Data.Context;
using MediatR;
using System;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
{
    private readonly AppDbContext _context;

    public GetClienteByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.FindAsync(request.Id);
        if (cliente == null) return null;

        return new Cliente
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Ativo = cliente.Ativo,
            TipoClienteId = cliente.TipoClienteId
        };
    }
}
