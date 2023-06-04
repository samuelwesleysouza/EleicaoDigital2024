
using EleicaoDigital.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace EleicaoDigital.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<tabPessoa> tabPessoa { get; set; }
        public DbSet<tabUsuario> tabUsuario { get; set; }
        public DbSet<tabPostUsuario> tabPostsUsuario{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<tabUsuario>().ToTable("tabUsuario");
            // modelBuilder.Entity<tabPostUsuario>().ToTable("tabPostUsuario");
           

           // modelBuilder.Entity<tabPessoa>().HasKey(v => v.Id);
           // modelBuilder.Entity<tabPessoa>().HasOne(a => a.UsuarioResponsavel).WithOne(b => b.Pessoa).HasForeignKey<tabPessoa>(e => e.UsuarioResponsavelCodigo);


          //  modelBuilder.Entity<tabPostUsuario>().HasKey(v => v.Id);
          //  modelBuilder.Entity<tabPostUsuario>().HasOne(a => a.Usuario).WithMany(b => b.PostsUsuarios);

        }

    }
}
