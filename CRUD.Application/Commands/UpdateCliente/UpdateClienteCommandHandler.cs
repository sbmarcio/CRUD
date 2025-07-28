using CRUD.Application.Commands.UpdateCliente;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Data.Context;
using MediatR;
using System;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateClienteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.FindAsync(request.Id);

        if (cliente == null) return false;

        cliente.Nome = request.Nome;
        cliente.Endereco = request.Endereco;
        cliente.Documento = request.Documento;
        cliente.Email = request.Email;
        cliente.Telefone = request.Telefone;
        cliente.Ativo = request.Ativo;
        cliente.TipoClienteId = request.TipoClienteId;
        cliente.DataAtualizacao = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
