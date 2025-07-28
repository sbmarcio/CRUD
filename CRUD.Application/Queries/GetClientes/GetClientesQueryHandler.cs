using CRUD.Application.Queries.GetClientes;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, IEnumerable<Cliente>>
{
    private readonly AppDbContext _context;

    public GetClientesQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Clientes.AsQueryable();

        return await query
            .Select(c => new Cliente
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                Documento = c.Documento,
                Email = c.Email,
                Telefone = c.Telefone,
                TipoClienteId = c.TipoClienteId,
                DataCriacao = c.DataCriacao,
                DataAtualizacao = c.DataAtualizacao,
                Ativo = c.Ativo
            })
            .ToListAsync(cancellationToken);
    }
}
