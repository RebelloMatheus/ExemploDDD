using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using System;
using System.Linq;

namespace DB_SERVER.Dominio.Validacoes.Entidades
{
    public class VotacaoValidado
    {
        private readonly IVotacoesRepositorio _votacoesRepositorio;

        public VotacaoValidado(IVotacoesRepositorio votacoesRepositorio)
        {
            _votacoesRepositorio = votacoesRepositorio;
        }

        public virtual Votacoes Validar(ref Votacoes votacao)
        {
            EstoriaUm(ref votacao);
            EstoriaDois(ref votacao);
            return votacao;
        }
        public virtual Votacoes EstoriaUm(ref Votacoes votacao)
        {
            DateTime data = votacao.Data;
            Guid ProfissionalId = votacao.ProfissionalId;
            if(_votacoesRepositorio.Listar().Where(c=>c.Data.Date.Equals(data.Date) && c.ProfissionalId.Equals(ProfissionalId)).Count()>0)
                votacao.Validacoes.Add(new ItemValidacao()
                {
                    NomePropriedade = "Data",
                    Mensagem = "Não é possível votar em mais de um restaurante por dia!"
                });
            return votacao;
        }
        public virtual Votacoes EstoriaDois(ref Votacoes votacao)
        {
            DateTime data = votacao.Data;
            Guid ProfissionalId = votacao.ProfissionalId;
            if (_votacoesRepositorio.Listar().Where(c =>
                c.ProfissionalId.Equals(ProfissionalId) &&
                c.Data.Date>=(data.AddDays(((int)data.DayOfWeek)*-1)).Date && c.Data.Date <= (data.AddDays((int)DayOfWeek.Saturday-(int)data.DayOfWeek)).Date).Count() > 0)
                votacao.Validacoes.Add(new ItemValidacao()
                {
                    NomePropriedade = "RestauranteId",
                    Mensagem = "O mesmo restaurante não pode ser escolhido mais de uma vez durante a semana."
                });
            return votacao;
        }
    }
}