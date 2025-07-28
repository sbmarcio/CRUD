using CRUD.Application.Commands.DeleteCliente;
using CRUD.Infrastructure.Data.Context;
using MediatR;
using System;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteClienteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.FindAsync(request.Id);
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
