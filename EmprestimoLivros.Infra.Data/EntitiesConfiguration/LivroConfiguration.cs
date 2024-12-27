using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoLivros.Infra.Data.EntitiesConfiguration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LivroNome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LivroAutor)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.LivroEditora)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LivroEdicao)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
