using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EmprestimoLivros.API.EntityConfig
{
    public class LivroClienteEmprestimoConfiguration : IEntityTypeConfiguration<LivroClienteEmprestimo>
    {
        public void Configure(EntityTypeBuilder<LivroClienteEmprestimo> builder)
        {
            builder.HasKey(lce => lce.Id);

            builder.Property(lce => lce.IdLivro)
                .IsRequired();

            builder.Property(lce => lce.IdCliente)
                .IsRequired();

            builder.Property(lce => lce.DataEmprestimo)
                .IsRequired();

            builder.Property(lce => lce.DataDevolucao)
                .IsRequired();

            builder.HasOne(lce => lce.Livro)
                .WithMany()
                .HasForeignKey(lce => lce.IdLivro);

            builder.HasOne(lce => lce.Cliente)
                .WithMany()
                .HasForeignKey(lce => lce.IdCliente);
        }
    }
}
