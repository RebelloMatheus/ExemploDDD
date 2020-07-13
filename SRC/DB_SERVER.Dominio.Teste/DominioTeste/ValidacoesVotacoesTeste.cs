using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Model;
using DB_SERVER.Dominio.Servicos;
using DB_SERVER.Dominio.Validacoes;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DB_SERVER.Dominio.Teste.DominioTeste
{
    public class ValidacoesVotacoesTeste
    {
        private Mock<IVotacoesRepositorio> mock;
        readonly Votacoes Votacao_SemErro = new Votacoes()
        {
            Data = DateTime.Now,
            RestauranteId = Guid.NewGuid(),
            Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
            ProfissionalId = Guid.NewGuid(),
            Profissional = new Profissionais() { Nome = "Profissional 1"}
        };
        readonly Votacoes Votacao2_ComErro = new Votacoes()
        {
            Data = DateTime.Now.AddDays(1),
            RestauranteId = Guid.NewGuid(),
            Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
            ProfissionalId = Guid.NewGuid(),
            Profissional = new Profissionais() { Nome = "Profissional 1" }
        };

        readonly Votacoes Votacao_MaisDeUmVotoDia = new Votacoes()
        {
            Data = DateTime.Now,
            RestauranteId = Guid.NewGuid(),
            Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
            ProfissionalId = Guid.NewGuid(),
            Profissional = new Profissionais() { Nome = "Profissional 1" }
        };

        public ValidacoesVotacoesTeste()
        {
            mock = new Mock<IVotacoesRepositorio>(MockBehavior.Default);
            Votacoes votacaoSemErroMock = new Votacoes()
            {
                Data = DateTime.Now,
                RestauranteId = Guid.NewGuid(),
                Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
                ProfissionalId = Guid.NewGuid(),
                Profissional = new Profissionais() { Nome = "Profissional 1" }
            };

            mock.Setup(cc => cc.Adicionar(Votacao_SemErro))
                .Returns(() => votacaoSemErroMock);

            Votacoes votacaoMaisDeUmVotoDiaMock = new Votacoes()
            {
                Data = DateTime.Now,
                RestauranteId = Guid.NewGuid(),
                Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
                ProfissionalId = Guid.NewGuid(),
                Profissional = new Profissionais() { Nome = "Profissional 1" }
            }; 
            votacaoMaisDeUmVotoDiaMock.Validacoes.Add(new ItemValidacao()
            {
                NomePropriedade = "Data",
                Mensagem = "Não é possível votar em mais de um restaurante por dia!"
            });

            mock.Setup(cc => cc.Adicionar(Votacao_MaisDeUmVotoDia))
                .Returns(() => votacaoMaisDeUmVotoDiaMock);

            Votacoes votacao2ComErroMock = new Votacoes()
            {
                Data = DateTime.Now.AddDays(1),
                RestauranteId = Guid.NewGuid(),
                Restaurante = new Restaurantes() { Nome = "Restaurante 1" },
                ProfissionalId = Guid.NewGuid(),
                Profissional = new Profissionais() { Nome = "Profissional 1" }
            };
            votacao2ComErroMock.Validacoes.Add(new ItemValidacao()
            {
                NomePropriedade = "Data",
                Mensagem = "Não é possível votar em mais de um restaurante por dia!"
            });

            mock.Setup(cc => cc.Adicionar(Votacao2_ComErro))
                .Returns(() => votacao2ComErroMock);
        }

        private List<ItemValidacao>? ValidacoesAdicionarFake(Votacoes votacoes)
        {
            VotacoesServico votacoesServico = new VotacoesServico(mock.Object);

            var retorno = votacoesServico.Adicionar(votacoes);

            return retorno.Validacoes;
        }

        [Fact]
        public void TestarAdicionarVotacaoMaisDeUmaVotacaoDia()
        {
            List<ItemValidacao> validacoes = ValidacoesAdicionarFake(Votacao_MaisDeUmVotoDia);
            var validacaoEsperada = new List<ItemValidacao>();
            validacaoEsperada.Add(new ItemValidacao()
            {
                NomePropriedade = "Data",
                Mensagem = "Não é possível votar em mais de um restaurante por dia!"
            }); 

            validacoes.Should().BeEquivalentTo(validacaoEsperada, "Resultado incorreto na validação de Votação, mais de um voto no dia.");
        }
        [Fact]
        public void TestarAdicionarVotacaoMaisDeUmaVotacaoSemana()
        {
            List<ItemValidacao> validacoes = ValidacoesAdicionarFake(Votacao2_ComErro);
            var validacaoEsperada = new List<ItemValidacao>();
            validacaoEsperada.Add(new ItemValidacao()
            {
                NomePropriedade = "Data",
                Mensagem = "Não é possível votar em mais de um restaurante por dia!"
            }); 

            validacoes.Should().BeEquivalentTo(validacaoEsperada, "Resultado incorreto na validação de Votação, mais de um voto na semana.");
        }

        [Fact]
        public void TestarAdicionarVotacaoComSucesso()
        {
            List<ItemValidacao> validacoes = ValidacoesAdicionarFake(Votacao_SemErro);
            var PessoaIdAux = Guid.NewGuid();
            var ContaIdAux = Guid.NewGuid();
            Votacoes ContaCorrente_Valida = new Votacoes()
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                RestauranteId = Guid.NewGuid(),
                Restaurante = new Restaurantes() {Id= Guid.NewGuid(), Nome = "Restaurante 1" },
                ProfissionalId = Guid.NewGuid(),
                Profissional = new Profissionais() { Id = Guid.NewGuid(), Nome = "Profissional 1" }
            };
            mock.Setup(cc => cc.Adicionar(ContaCorrente_Valida))
                .Returns(() => new Votacoes());

            validacoes.Should().BeNullOrEmpty("As regras de validações não foram atendidas.");
        }
    }
}