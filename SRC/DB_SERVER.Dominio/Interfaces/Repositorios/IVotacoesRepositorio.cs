using DB_SERVER.Dominio.Model;
using System;
using System.Collections.Generic;

namespace DB_SERVER.Dominio.Interfaces.Repositorios
{
    public interface IVotacoesRepositorio : IRepositorio<Votacoes>
    {
        Votacoes ObterRestauranteVencedorParaDia(DateTime data); 
        IEnumerable<Votacoes> ListarCompleto(); 
    }
}