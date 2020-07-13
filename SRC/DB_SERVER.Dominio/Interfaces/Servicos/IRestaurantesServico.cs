using DB_SERVER.Dominio.Model;
using System;

namespace DB_SERVER.Dominio.Interfaces.Servicos
{
    public interface IRestaurantesServico : IDisposable
    {
        Restaurantes Adicionar(Restaurantes restaurante);
        Restaurantes Atualizar(Restaurantes restaurante);
        void Remover(Restaurantes restaurante);

    }
}