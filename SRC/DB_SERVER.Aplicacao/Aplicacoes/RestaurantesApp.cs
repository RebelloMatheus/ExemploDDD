using AutoMapper;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;
using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_SERVER.Aplicacao.Aplicacoes
{
    public class RestaurantesApp : BaseApp, IRestaurantesApp
    {
        private readonly IRestaurantesRepositorio _restaurantesRepositorio;
        private readonly IRestaurantesServico _restaurantesServico;
        private readonly IMapper _mapper;

        public RestaurantesApp(IRestaurantesRepositorio restaurantesRepositorio, IRestaurantesServico restaurantesServico, IMapper mapper, ITransacao trans)
            : base(trans)
        {
            _restaurantesRepositorio = restaurantesRepositorio;
            _restaurantesServico = restaurantesServico;
            _mapper = mapper;
        }
        public RestaurantesViewModel Adicionar(RestaurantesViewModel restaurante)
        {
            var restauranteRetorno = _restaurantesServico.Adicionar(_mapper.Map<Restaurantes>(restaurante));

            if (!restauranteRetorno.Validacoes.Any())
                Commit();

            return _mapper.Map<RestaurantesViewModel>(restauranteRetorno);
        }

        public RestaurantesViewModel Atualizar(RestaurantesViewModel restaurante)
        {
            var restauranteRetorno = _restaurantesServico.Atualizar(_mapper.Map<Restaurantes>(restaurante));

            if (!restauranteRetorno.Validacoes.Any())
                Commit();

            return _mapper.Map<RestaurantesViewModel>(restauranteRetorno);
        }

        public IEnumerable<RestaurantesViewModel> Listar()
        {
            return _mapper.Map<IEnumerable<RestaurantesViewModel>>(_restaurantesRepositorio.Listar());
        }

        public RestaurantesViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<RestaurantesViewModel>(_restaurantesRepositorio.ObterPorId(id));
        }

        public void Remover(RestaurantesViewModel restaurante)
        {
            _restaurantesServico.Remover(_mapper.Map<Restaurantes>(restaurante));
        }
    }
}