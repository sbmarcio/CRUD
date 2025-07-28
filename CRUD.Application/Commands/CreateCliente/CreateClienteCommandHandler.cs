using MediatR;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Data.Context;
using CRUD.Application.Commands.CreateCliente;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
{
    private readonly AppDbContext _context;

    public CreateClienteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Nome = request.Nome,
            Endereco = request.Endereco,
            Documento = request.Documento,
            Email = request.Email,
            Telefone = request.Telefone,
            TipoClienteId = request.TipoClienteId,
            DataCriacao = DateTime.UtcNow,
            DataAtualizacao = DateTime.UtcNow,
            Ativo = true
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync(cancellationToken);

        return cliente.Id;
    }
}
