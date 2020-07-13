using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Dominio.Validacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_SERVER.Dominio.Servicos
{
    public class VotacoesServico : IVotacoesServico
    {
        public readonly IVotacoesRepositorio _votacoesRepositorio;
        public VotacoesServico(IVotacoesRepositorio votacoesRepositorio)
        {
            _votacoesRepositorio = votacoesRepositorio;
        }

        public Votacoes Adicionar(Votacoes votacao)
        {
            var validacao = new VotacaoValidado(_votacoesRepositorio);
            votacao = validacao.Validar(ref votacao);

            if (!votacao.Validacoes.Any())
                votacao = _votacoesRepositorio.Adicionar(votacao);

            return votacao;
        }

        public Votacoes Atualizar(Votacoes votacao)
        {
            var validacao = new VotacaoValidado(_votacoesRepositorio);
            votacao = validacao.Validar(ref votacao);

            if (!votacao.Validacoes.Any())
                votacao = _votacoesRepositorio.Atualizar(votacao);

            return votacao;
        }

        public void Dispose()
        {
            _votacoesRepositorio.Dispose();
        }

        public IEnumerable<Votacoes> ListarCompleto()
        {
            return _votacoesRepositorio.ListarCompleto();
        }

        public Votacoes ObterRestauranteVencedorParaDia(DateTime data)
        {
            return _votacoesRepositorio.ObterRestauranteVencedorParaDia(data);
        }

        public void Remover(Votacoes votacao)
        {
            _votacoesRepositorio.Remover(votacao);
        }
    }
}