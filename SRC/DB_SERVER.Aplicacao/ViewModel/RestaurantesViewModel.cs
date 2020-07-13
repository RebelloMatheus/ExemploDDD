using DB_SERVER.Aplicacao.ViewModel.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_SERVER.Aplicacao.ViewModel
{
    public class RestaurantesViewModel : ValidacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(120, ErrorMessage = "Informe no máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Informe no mínimo {0} caracteres")]
        public string Nome { get; set; }
        [NotMapped]
        public virtual IEnumerable<VotacoesViewModel> Votacoes { get; set; }
    }
}