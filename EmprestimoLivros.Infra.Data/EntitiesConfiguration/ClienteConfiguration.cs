using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoLivros.Infra.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CliCpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.CliNome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CliEndereco)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CliCidade)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CliBairro)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CliNumero)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.CliTelefoneCelular)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.CliTelefoneFixo)
                .HasMaxLength(10)
                .IsRequired();

        }
    }
}
