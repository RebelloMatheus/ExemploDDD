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
    public class VotacoesApp : BaseApp, IVotacoesApp
    {
        private readonly IVotacoesRepositorio _votacoesRepositorio;
        private readonly IVotacoesServico _votacoesServico;
        private readonly IMapper _mapper;

        public VotacoesApp(IVotacoesRepositorio votacoesRepositorio, IVotacoesServico votacoesServico, IMapper mapper, ITransacao trans)
            : base(trans)
        {
            _votacoesRepositorio = votacoesRepositorio;
            _votacoesServico = votacoesServico;
            _mapper = mapper;
        }
        public VotacoesViewModel Adicionar(VotacoesViewModel votacao)
        {
            var votacaoRetorno = _votacoesServico.Adicionar(_mapper.Map<Votacoes>(votacao));

            if (!votacaoRetorno.Validacoes.Any())
                Commit();
            votacao = _mapper.Map<VotacoesViewModel>(votacaoRetorno);

            return votacao;
        }

        public VotacoesViewModel Atualizar(VotacoesViewModel votacao)
        {
            var votacaoRetorno = _votacoesServico.Atualizar(_mapper.Map<Votacoes>(votacao));

            if (!votacaoRetorno.Validacoes.Any())
                Commit();

            return _mapper.Map<VotacoesViewModel>(votacaoRetorno);
        }

        public IEnumerable<VotacoesViewModel> Listar()
        {
            return _mapper.Map<IEnumerable<VotacoesViewModel>>(_votacoesRepositorio.Listar());
        }

        public IEnumerable<VotacoesViewModel> ListarCompleto()
        {
            return _mapper.Map<IEnumerable<VotacoesViewModel>>(_votacoesRepositorio.ListarCompleto());
        }

        public VotacoesViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<VotacoesViewModel>(_votacoesRepositorio.ObterPorId(id));
        }

        public VotacoesViewModel ObterRestauranteVencedorParaDia(DateTime data)
        {
            return _mapper.Map<VotacoesViewModel>(_votacoesServico.ObterRestauranteVencedorParaDia(data));
        }

        public void Remover(VotacoesViewModel votacao)
        {
            _votacoesServico.Remover(_mapper.Map<Votacoes>(votacao));
        }
    }
}