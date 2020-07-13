using DB_SERVER.Aplicacao.ViewModel.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_SERVER.Aplicacao.ViewModel
{
    public class VotacoesViewModel : ValidacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Profissional")]
        public Guid ProfissionalId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name ="Restaurante")]
        public Guid RestauranteId { get; set; }

        [NotMapped]
        public virtual RestaurantesViewModel Restaurante { get; set; }

        [NotMapped]
        public virtual ProfissionaisViewModel Profissional { get; set; }
    }
}