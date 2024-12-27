using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoLivros.Infra.Data.EntitiesConfiguration
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LceIdCliente)
                .IsRequired();

            builder.Property(x => x.LceIdLivro)
                .IsRequired();

            builder.Property(x => x.LceDataEmprestimo)
                .IsRequired();

            builder.Property(x => x.LceDataEntrega)
                .IsRequired();

            builder.Property(x => x.LceEntregue)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Emprestimos)
                .HasForeignKey(x => x.LceIdCliente)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Livro)
                .WithMany(x => x.Emprestimos)
                .HasForeignKey(x => x.LceIdLivro)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
