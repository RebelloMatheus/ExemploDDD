using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Infra.Data.Configuracao;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Dapper;

namespace DB_SERVER.Infra.Data.Repositorios
{
    public class VotacoesRepositorio : RepositorioBase<Votacoes>, IVotacoesRepositorio
    {
        public VotacoesRepositorio(Contexto contexto) : base(contexto)
        {
        }
        public IEnumerable<Votacoes> ListarCompleto()
        {
            using (var connection = Db.Database.GetDbConnection())
            {

                var query = @"SELECT * FROM  Votacoes V
                            INNER JOIN Profissionais P ON P.Id = V.ProfissionalId
                            INNER JOIN Restaurantes  R ON R.Id = V.RestauranteId
                        ";

                return connection.Query<Votacoes, Profissionais, Restaurantes, Votacoes>
                    (query, (votacao, profissional, restaurante)=> 
                        {
                            votacao.Restaurante = restaurante;
                            votacao.Profissional = profissional;
                            return votacao;
                        }
                    ).ToList();
            }
        }

        public Votacoes ObterRestauranteVencedorParaDia(DateTime data)
        {
            using (var connection = Db.Database.GetDbConnection())
            {

                var query = @"SELECT TOP 1 RestauranteId, R.Nome FROM  Votacoes V
                            INNER JOIN Restaurantes  R ON R.Id = V.RestauranteId
                           Where CAST(Data as Date) = CAST(@uDataPesquisa AS Date)
                            GROUP BY RestauranteId, R.Nome
                            ORDER BY COUNt(RestauranteId) DESC
                        ";
                return connection.Query<Votacoes, Restaurantes, Votacoes>
                        (query, (votacao, restaurante) =>
                        {
                            votacao.Restaurante = restaurante;
                            return votacao;
                        }, new { uDataPesquisa = data.Date}, splitOn: "RestauranteId,Nome"
                        ).FirstOrDefault();
            }
        }
    }
}