using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB_SERVER.Dominio.Model
{
    public class Profissionais:EntidadeBase
    {
        [Display(Name ="Profissional")]
        public string Nome { get; set; }

        public virtual IEnumerable<Votacoes> Votacoes { get; set; }
    }
}