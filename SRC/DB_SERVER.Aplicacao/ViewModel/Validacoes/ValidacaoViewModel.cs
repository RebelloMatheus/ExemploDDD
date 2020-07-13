using System.Collections.Generic;

namespace DB_SERVER.Aplicacao.ViewModel.Validacoes
{
    public abstract class ValidacaoViewModel
    {
        public ValidacaoViewModel()
        {
            Validacoes = new List<ItemValidacaoViewModel>();
        }

        public List<ItemValidacaoViewModel> Validacoes { get; set; }
    }
}