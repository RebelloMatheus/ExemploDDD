# Projeto ExemploDDD
> Uso de padrão DDD com aspnet core 3.1, usando ORM Entity Framework Core e banco de dados SQL Server.

O projeto foi criado para dar visibilidade de meus conhecimentos técnicos, como uso do padrão DDD, ORM e Testes. 
Juntamente de uma organização, escrita de código, sua distribuição e formas de cobertura de testes. 

## Detalhe do Projeto

Os times da DBserver enfrentam um grande problema. Como eles são muito democráticos, todos os dias eles gastam 30 minutos decidindo onde eles irão almoçar.
Vamos fazer um pequeno sistema que auxilie essa tomada de decisão!


## Estórias 

### Estória 1
Eu como profissional faminto
Quero votar no meu restaurante favorito
Para que eu consiga democraticamente levar meus colegas a comer onde eu gosto.

#### Critério de Aceitação
•	Um profissional só pode votar em um restaurante por dia.


### Estória 2
Eu como facilitador do processo de votação
Quero que um restaurante não possa ser repetido durante a semana
Para que não precise ouvir reclamações infinitas!

#### Critério de Aceitação
•	O mesmo restaurante não pode ser escolhido mais de uma vez durante a semana.


### Estória 3
Eu como profissional faminto
Quero saber antes do meio dia qual foi o restaurante escolhido
Para que eu possa me despir de preconceitos e preparar o psicológico.

#### Critério de Aceitação
•	Mostrar de alguma forma o resultado da votação.


## Domínios
Foram criados 3 modelos de domínios no sistema:
1. __Votações__;
2. __Profissionais__;
3. __Restaurantes__.


## Requisitos de ambiente
1. Ambiente para rodar .Net Core 
2. SqlServer


### Instalação

#### Configurar conexão ao banco de dados
Configurar no arquivo DB_SERVER.UI/appsettings.json

#### Executar o migration
No Console do Gerenciador de Pacotes
1. Selecione 4 - Infra\DB_SERVER.Infra.Data  
2. Execute o comando update-database ou script-migration para gerar script manual.


## Detalhamento Técnico
O App foi desenvolvido sob a plataforma .Net 3.1

Na camada de Interface foi utilizado o template nativo da Microsoft:
1. [Razor](https://docs.microsoft.com/pt-br/aspnet/core/razor-pages/?view=aspnetcore-3.1&tabs=visual-studio)
2. [Bootstrap](https://getbootstrap.com/docs/4.5/getting-started/introduction)

Nos demais projetos da solução foram utilizados os seguintes componentes
1. Entity Framework Core - Pacote: Microsoft.EntityFrameworkCore.Tools (v3.1.5)
2. Banco de Dados SQL Server - Pacote: Microsoft.EntityFrameworkCore.SqlServer (v3.1.5)
3. AutoMapper - Pacote: AutoMapper.Extensions.Microsoft.DependencyInjection (v7.0.0)

### Cobertura de Testes
Os testes desenvolvidos foram criados para dar sustentação nas principal operação do sistema, como votações.

Para os casos foram utilizados os componentes:
1. Moq - Pacote: Moq (v4.14.5)
2. xUnit - Pacote: xunit (v2.4.0)
3. FluentAssertions - Pacote: FluentAssertions (v5.10.3)


