using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB_SERVER.Infra.Data.Configuracao.Entidades
{
    public class RestaurantesConfig : ConfigBase<Restaurantes>, IEntityTypeConfiguration<Restaurantes>, IEntidadeConfig
    {
        public void Configure(EntityTypeBuilder<Restaurantes> entidade)
        {
            Padronizacao(entidade, nomeTabela: "Restaurantes");

            entidade
                .Property(cc => cc.Nome)
                .HasMaxLength(255)
                .IsRequired();

            entidade
               .HasMany(cc => cc.Votacoes)
               .WithOne(o => o.Restaurante)
               .OnDelete(DeleteBehavior.NoAction)
               .HasForeignKey(cc => cc.RestauranteId);
        }
    }
}