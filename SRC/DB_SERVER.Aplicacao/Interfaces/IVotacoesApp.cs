using DB_SERVER.Aplicacao.ViewModel;
using System;
using System.Collections.Generic;

namespace DB_SERVER.Aplicacao.Interfaces
{
    public interface IVotacoesApp : IBaseApp<VotacoesViewModel>
    {
        VotacoesViewModel ObterRestauranteVencedorParaDia(DateTime data); 
        IEnumerable<VotacoesViewModel> ListarCompleto();
    }
}