using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmprestimoLivros.API.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CliCpf)
                .IsRequired()
                .HasMaxLength(14).
                HasColumnName("cliCPF");

            builder.Property(c => c.CliNome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("cliNome");

            builder.Property(c => c.CliEndereco)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("cliEndereco");

            builder.Property(c => c.CliCidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("cliCidade");

            builder.Property(c => c.CliBairro)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("cliBairro");

            builder.Property(c => c.CliNumero)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("cliNumero");

            builder.Property(c => c.CliTelefoneCelular)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("cliTelefoneCelular");

            builder.Property(c => c.CliTelefoneFixo)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("cliTelefoneFixo");

         
        }
    }
}