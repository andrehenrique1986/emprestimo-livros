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

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}