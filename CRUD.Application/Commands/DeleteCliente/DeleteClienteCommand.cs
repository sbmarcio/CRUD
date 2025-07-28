using MediatR;

namespace CRUD.Application.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteClienteCommand(int id) => Id = id;
    }
}