using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DB_SERVER.Infra.Data.Configuracao
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Profissionais> Profissionais { get; set; }
        public DbSet<Restaurantes> Restaurantes { get; set; }
        public DbSet<Votacoes> Votacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var registrosEntidades = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntidadeConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            foreach (var tipo in registrosEntidades)
            {
                dynamic configurandoInstancia = Activator.CreateInstance(tipo);
                modelBuilder.ApplyConfiguration(configurandoInstancia);
            }
        }
    }
}