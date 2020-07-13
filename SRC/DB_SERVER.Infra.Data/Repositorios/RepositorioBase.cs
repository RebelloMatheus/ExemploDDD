using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_SERVER.Infra.Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T>, IDisposable where T : EntidadeBase, new()
    {
        protected Contexto Db;
        protected DbSet<T> DbSet;

        public RepositorioBase(Contexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<T>();
        }

        public virtual T Adicionar(T obj)
        {
            var newObj = DbSet.Add(obj);
            return newObj.Entity;
        }

        public virtual T Atualizar(T obj)
        {
            var newObj = DbSet.Update(obj);
            return newObj.Entity;
        }

        public virtual void Remover(T obj)
        {
            DbSet.Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public T ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}