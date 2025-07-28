using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Data.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(c => c.Endereco)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);

        builder.Property(c => c.Documento)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.HasIndex(c => c.Documento)
            .IsUnique();

        builder.Property(c => c.Email)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(c => c.Telefone)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(c => c.DataCriacao)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(c => c.DataAtualizacao)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(c => c.Ativo)
            .HasColumnType("BIT")
            .IsRequired();

        builder.HasOne(c => c.TipoCliente)
            .WithMany()
            .HasForeignKey(c => c.TipoClienteId);
    }
}
