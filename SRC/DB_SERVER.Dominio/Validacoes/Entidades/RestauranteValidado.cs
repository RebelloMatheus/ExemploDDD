using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;

namespace DB_SERVER.Dominio.Validacoes.Entidades
{
    public class RestauranteValidado
    {
        private readonly IRestaurantesRepositorio _restaurantesRepositorio;

        public RestauranteValidado(IRestaurantesRepositorio restaurantesRepositorio)
        {
            _restaurantesRepositorio = restaurantesRepositorio;
        }

        public virtual Restaurantes Validar(ref Restaurantes restaurante)
        {
            return restaurante;
        }
    }
}