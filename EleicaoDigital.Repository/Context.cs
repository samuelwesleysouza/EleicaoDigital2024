
using EleicaoDigital.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace EleicaoDigital.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<tabUsuario> tabUsuario { get; set; }
        public DbSet<tabPublicacao> tabPublicacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
