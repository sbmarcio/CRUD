using MediatR;

namespace CRUD.Application.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public int TipoClienteId { get; set; }
    }
}
