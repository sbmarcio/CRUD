using MediatR;
using CRUD.Domain.Entities;

namespace CRUD.Application.Queries.GetClientes
{
    public class GetClientesQuery : IRequest<IEnumerable<Cliente>>
    {
        
    }
}
