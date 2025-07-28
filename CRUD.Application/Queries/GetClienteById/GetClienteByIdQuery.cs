using MediatR;
using CRUD.Domain.Entities;

namespace CRUD.Application.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public int Id { get; set; }

        public GetClienteByIdQuery(int id) => Id = id;
    }
}