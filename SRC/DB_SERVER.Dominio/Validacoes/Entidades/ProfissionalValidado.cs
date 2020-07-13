using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;

namespace DB_SERVER.Dominio.Validacoes.Entidades
{
    public class ProfissionalValidado
    {
        private readonly IProfissionaisRepositorio _profissionaisRepositorio;

        public ProfissionalValidado(IProfissionaisRepositorio profissionaisRepositorio)
        {
            _profissionaisRepositorio = profissionaisRepositorio;
        }

        public virtual Profissionais Validar(ref Profissionais profissional)
        {

            return profissional;
        }
    }
}