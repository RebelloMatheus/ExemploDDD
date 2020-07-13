using DB_SERVER.Infra.Data.Configuracao;
using DB_SERVER.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_SERVER.Infra.Data.UoW
{
    public class Transacao : ITransacao
    {
        private readonly Contexto _contexto;
        public Transacao(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}