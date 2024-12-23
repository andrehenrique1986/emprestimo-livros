using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoLivros.API.EntityConfig
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Editora)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}