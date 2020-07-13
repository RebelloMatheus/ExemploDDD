using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao;

namespace DB_SERVER.Infra.Data.Repositorios
{
    public class RestaurantesRepositorio : RepositorioBase<Restaurantes>, IRestaurantesRepositorio
    {
        public RestaurantesRepositorio(Contexto contexto) : base(contexto)
        {
        } 
    }
}