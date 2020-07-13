using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB_SERVER.Infra.Data.Configuracao.Entidades
{
    public class ProfissionaisConfig : ConfigBase<Profissionais>, IEntityTypeConfiguration<Profissionais>, IEntidadeConfig
    {
        public void Configure(EntityTypeBuilder<Profissionais> entidade)
        { 
            Padronizacao(entidade, nomeTabela: "Profissionais");

            entidade
                .Property(cc => cc.Nome)
                .HasMaxLength(255)
                .IsRequired();
            entidade
               .HasMany(cc => cc.Votacoes)
               .WithOne(o => o.Profissional)
               .OnDelete(DeleteBehavior.NoAction)
               .HasForeignKey(cc => cc.ProfissionalId);
        }
    }
}