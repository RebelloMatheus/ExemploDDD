using DB_SERVER.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB_SERVER.Infra.Data.Configuracao
{
    public class ConfigBase<TEntity> where TEntity : EntidadeBase
    {
        public void Padronizacao(EntityTypeBuilder<TEntity> entidade, string nomeTabela)
        {
            entidade.ToTable(nomeTabela);
            entidade.HasKey(x => x.Id);
        }
    }
}