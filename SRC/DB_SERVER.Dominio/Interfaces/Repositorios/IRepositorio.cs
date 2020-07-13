using System;
using System.Collections.Generic;

namespace DB_SERVER.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<T> : IDisposable where T : class
    {
        T Adicionar(T obj);
        T Atualizar(T obj);
        void Remover(T obj);
        T ObterPorId(Guid id);
        IEnumerable<T> Listar();
    }
}