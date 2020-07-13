using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB_SERVER.Infra.Data.Configuracao.Entidades
{
    public class VotacoesConfig : ConfigBase<Votacoes>, IEntityTypeConfiguration<Votacoes>, IEntidadeConfig
    {
        public void Configure(EntityTypeBuilder<Votacoes> entidade)
        {
            Padronizacao(entidade, nomeTabela: "Votacoes");

            entidade
                .HasIndex(cc => new { cc.Data, cc.ProfissionalId, cc.RestauranteId }).IsUnique();

        }
    }
}