using Exoapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exoapi.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }
        public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-MVT3RCM3\\SQLEXPRESS; initial catalog = Exoapi;Integrated Security = true");
            }
        }
            public DbSet<Projeto>? Projetos { get; set; } //<nome da classe model> nome da tabela no bd
            public DbSet<Usuario>? Usuarios { get; set; }


    }
}