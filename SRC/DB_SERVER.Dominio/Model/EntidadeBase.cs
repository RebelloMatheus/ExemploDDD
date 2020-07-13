using DB_SERVER.Dominio.Validacoes;
using System;

namespace DB_SERVER.Dominio.Model
{
    public abstract class EntidadeBase : Validacao
    {
        public Guid Id { get; set; }
    }
}