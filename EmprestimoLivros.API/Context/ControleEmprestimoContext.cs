using EmprestimoLivros.API.EntityConfig;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmprestimoLivros.API.Context
{
    public class ControleEmprestimoContext : DbContext
    {
        public ControleEmprestimoContext(DbContextOptions<ControleEmprestimoContext> options)
            : base(options)
        {
        }

        public ControleEmprestimoContext()
        {

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para remover exclusão em cascata em relações um-para-muitos
            modelBuilder.Model.GetEntityTypes()
                .Where(t => t.GetForeignKeys().Any(fk => fk.DeleteBehavior == DeleteBehavior.Cascade))
                .ToList()
                .ForEach(t => t.GetForeignKeys().ToList().ForEach(fk =>
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict; // Ou NoAction, dependendo do seu caso
                }));

            // Configura as chaves primárias
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var primaryKeyProperty = entity.GetProperties().FirstOrDefault(p => p.Name.StartsWith("Id"));
                if (primaryKeyProperty != null)
                {
                    entity.FindProperty(primaryKeyProperty.Name).IsPrimaryKey();
                }
            }

            // Configura todas as propriedades string para o tipo de coluna "varchar"
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetColumnType("varchar");
                        property.SetMaxLength(100); // Definindo comprimento máximo para todas as strings
                    }
                }
            }

            // Desabilita a pluralização automática
            modelBuilder.Model.GetEntityTypes()
                .ToList()
                .ForEach(entity => entity.SetTableName(entity.GetTableName().ToLowerInvariant()));


            // Definir as tabelas explicitamente
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<LivroClienteEmprestimo>().ToTable("Livro_Cliente_Emprestimo");

            // Aplicar as configurações específicas das entidades
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new LivroClienteEmprestimoConfiguration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
