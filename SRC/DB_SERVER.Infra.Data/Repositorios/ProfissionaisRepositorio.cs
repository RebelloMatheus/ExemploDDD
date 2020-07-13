using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao;

namespace DB_SERVER.Infra.Data.Repositorios
{
    public class ProfissionaisRepositorio : RepositorioBase<Profissionais>, IProfissionaisRepositorio
    {
        public ProfissionaisRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}