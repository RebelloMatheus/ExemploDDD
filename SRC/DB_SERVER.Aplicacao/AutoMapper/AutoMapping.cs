using AutoMapper;
using DB_SERVER.Aplicacao.ViewModel;
using DB_SERVER.Aplicacao.ViewModel.Validacoes;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Dominio.Validacoes;

namespace DB_SERVER.Aplicacao.AutoMapper
{
    public class AutoMapping : Profile
    {
        public MapperConfiguration Configuracao()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Profissionais, ProfissionaisViewModel>().ReverseMap();
                cfg.CreateMap<Restaurantes, RestaurantesViewModel>().ReverseMap();
                cfg.CreateMap<Votacoes, VotacoesViewModel>().ReverseMap();
                cfg.CreateMap<ItemValidacao, ItemValidacaoViewModel>().ReverseMap();
            });
        }
    }
}