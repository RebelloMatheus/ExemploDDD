using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Dominio.Validacoes.Entidades;
using System.Linq;

namespace DB_SERVER.Dominio.Servicos
{
    public class ProfissionaisServico : IProfissionaisServico
    {
        public readonly IProfissionaisRepositorio _profissionaisRepositorio;
        public ProfissionaisServico(IProfissionaisRepositorio profissionaisRepositorio)
        {
            _profissionaisRepositorio = profissionaisRepositorio;
        }

        public Profissionais Adicionar(Profissionais profissional)
        {
            var validacao = new ProfissionalValidado(_profissionaisRepositorio);
            profissional = validacao.Validar(ref profissional);

            if (!profissional.Validacoes.Any())
                profissional = _profissionaisRepositorio.Adicionar(profissional);

            return profissional;
        }

        public Profissionais Atualizar(Profissionais profissional)
        {
            var validacao = new ProfissionalValidado(_profissionaisRepositorio);
            profissional = validacao.Validar(ref profissional);

            if (!profissional.Validacoes.Any())
                profissional = _profissionaisRepositorio.Atualizar(profissional);

            return profissional;
        }

        public void Dispose()
        {
            _profissionaisRepositorio.Dispose();
        }

        public void Remover(Profissionais profissional)
        {
            _profissionaisRepositorio.Remover(profissional);
        }
    }
}