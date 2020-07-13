using DB_SERVER.Dominio.Model;
using System;
using System.Collections.Generic;

namespace DB_SERVER.Dominio.Interfaces.Servicos
{
    public interface IVotacoesServico : IDisposable
    {
        Votacoes Adicionar(Votacoes votacao);
        Votacoes Atualizar(Votacoes votacao);
        void Remover(Votacoes votacao);
        Votacoes ObterRestauranteVencedorParaDia(DateTime data); 
        IEnumerable<Votacoes> ListarCompleto();
    }
}