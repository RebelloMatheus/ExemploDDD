using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB_SERVER.Dominio.Model
{
    public class Restaurantes : EntidadeBase
    {
        [Display(Name = "Restaurante")]
        public string Nome { get; set; } 
        public virtual IEnumerable<Votacoes> Votacoes { get; set; }
    }
}