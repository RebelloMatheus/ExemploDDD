using System.ComponentModel.DataAnnotations.Schema;

namespace DB_SERVER.Dominio.Validacoes
{
    public class ItemValidacao
    {
        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }
    }
}