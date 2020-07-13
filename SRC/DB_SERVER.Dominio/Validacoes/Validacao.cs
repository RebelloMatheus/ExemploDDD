using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_SERVER.Dominio.Validacoes
{
    public abstract class Validacao
    {
        public Validacao()
        {
            Validacoes = new List<ItemValidacao>();
        }

        [NotMapped]
        public List<ItemValidacao> Validacoes { get; set; }
    }
}