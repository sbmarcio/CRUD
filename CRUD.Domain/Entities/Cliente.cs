using CRUD.Domain.Interfaces;

namespace CRUD.Domain.Entities
{
    public class Cliente : IAggregateRoot
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string Documento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public int TipoClienteId { get; set; }
        public TipoCliente TipoCliente { get; set; }
    }
}

