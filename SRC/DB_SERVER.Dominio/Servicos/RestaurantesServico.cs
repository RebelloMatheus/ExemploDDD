using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Dominio.Validacoes.Entidades;
using System.Linq;

namespace DB_SERVER.Dominio.Servicos
{
    public class RestaurantesServico : IRestaurantesServico
    {
        public readonly IRestaurantesRepositorio _restaurantesRepositorio;
        public RestaurantesServico(IRestaurantesRepositorio restaurantesRepositorio)
        {
            _restaurantesRepositorio = restaurantesRepositorio;
        }

        public Restaurantes Adicionar(Restaurantes restaurante)
        {
            var validacao = new RestauranteValidado(_restaurantesRepositorio);
            restaurante = validacao.Validar(ref restaurante);

            if (!restaurante.Validacoes.Any())
                restaurante = _restaurantesRepositorio.Adicionar(restaurante);

            return restaurante;
        }

        public Restaurantes Atualizar(Restaurantes restaurante)
        {
            var validacao = new RestauranteValidado(_restaurantesRepositorio);
            restaurante = validacao.Validar(ref restaurante);

            if (!restaurante.Validacoes.Any())
                restaurante = _restaurantesRepositorio.Atualizar(restaurante);

            return restaurante;
        }

        public void Dispose()
        {
            _restaurantesRepositorio.Dispose();
        }

        public void Remover(Restaurantes restaurante)
        {
            _restaurantesRepositorio.Remover(restaurante);
        }
    }
}