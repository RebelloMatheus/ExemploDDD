using System;

namespace DB_SERVER.Dominio.Model
{
    public class Votacoes : EntidadeBase
    {
        public DateTime Data { get; set; }
        public Guid ProfissionalId { get; set; }
        public Guid RestauranteId { get; set; }
        public virtual Restaurantes Restaurante { get; set; }
        public virtual Profissionais Profissional { get; set; }
    }
}