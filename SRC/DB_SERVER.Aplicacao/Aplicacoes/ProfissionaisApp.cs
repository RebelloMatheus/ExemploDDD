using AutoMapper;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;
using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_SERVER.Aplicacao.Aplicacoes
{
    public class ProfissionaisApp : BaseApp, IProfissionaisApp
    {
        private readonly IProfissionaisRepositorio _profissionaisRepositorio;
        private readonly IProfissionaisServico _profissionaisServico;
        private readonly IMapper _mapper;

        public ProfissionaisApp(IProfissionaisRepositorio profissionaisRepositorio, IProfissionaisServico profissionaisServico, IMapper mapper, ITransacao trans)
            :base(trans)
        {
            _profissionaisRepositorio = profissionaisRepositorio;
            _profissionaisServico = profissionaisServico;
            _mapper = mapper;
        }
        public ProfissionaisViewModel Adicionar(ProfissionaisViewModel profissional)
        {
            var profissionalRetorno = _profissionaisServico.Adicionar(_mapper.Map<Profissionais>(profissional));

            if (!profissionalRetorno.Validacoes.Any())
                Commit();

            return _mapper.Map<ProfissionaisViewModel>(profissionalRetorno);
        }

        public ProfissionaisViewModel Atualizar(ProfissionaisViewModel profissional)
        {
            var profissionalRetorno = _profissionaisServico.Atualizar(_mapper.Map<Profissionais>(profissional));

            if (!profissionalRetorno.Validacoes.Any())
                Commit();

            return _mapper.Map<ProfissionaisViewModel>(profissionalRetorno);
        }

        public IEnumerable<ProfissionaisViewModel> Listar()
        {
            return _mapper.Map<IEnumerable<ProfissionaisViewModel>>(_profissionaisRepositorio.Listar());
        }

        public ProfissionaisViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ProfissionaisViewModel>(_profissionaisRepositorio.ObterPorId(id));
        }

        public void Remover(ProfissionaisViewModel profissional)
        {
            _profissionaisServico.Remover(_mapper.Map<Profissionais>(profissional));
        }
    }
}