namespace CRUD.Domain.Entities
{
    public class TipoCliente
    {
        public TipoCliente()
        {
            Id = Id;
            Descricao = Descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}