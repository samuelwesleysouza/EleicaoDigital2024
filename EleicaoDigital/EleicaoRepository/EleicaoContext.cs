using EleicaoRepository.ModelsTabelaSql;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EleicaoRepository
{
    public class EleicaoContext: DbContext
    {
        public EleicaoContext(DbContextOptions<EleicaoContext> options) : base(options) { }

        public DbSet<TabUsuario> Usuarios { get; set; }
        public DbSet<TabelaEmployee> TabelaEmployee { get; set; }

        public DbSet<TabPostUsuario> TabPostUsuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabCadastro");
            modelBuilder.Entity<TabelaEmployee>().ToTable("tabFile");
            modelBuilder.Entity<TabPostUsuario>().ToTable("tabPostUsuario");
        }
    }
}