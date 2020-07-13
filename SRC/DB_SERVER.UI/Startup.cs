using AutoMapper;
using DB_SERVER.Aplicacao.Aplicacoes;
using DB_SERVER.Aplicacao.AutoMapper;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Dominio.Interfaces.Repositorios;
using DB_SERVER.Dominio.Interfaces.Servicos;
using DB_SERVER.Dominio.Servicos;
using DB_SERVER.Infra.Data.Configuracao;
using DB_SERVER.Infra.Data.Interfaces;
using DB_SERVER.Infra.Data.Repositorios;
using DB_SERVER.Infra.Data.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DB_SERVER.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            var connection = Configuration["ConnectionStrings:restaurante"];
            services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(connection )); 

            services.AddControllersWithViews();

            RegistrarLifeStyle(services);

            RegistrarAutoMapper(services);

            RegistrarAcessoSeguro(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private void RegistrarLifeStyle(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped<ITransacao, Transacao>();
            services.AddScoped<IProfissionaisApp, ProfissionaisApp>();
            services.AddScoped<IProfissionaisRepositorio, ProfissionaisRepositorio>();
            services.AddScoped<IProfissionaisServico, ProfissionaisServico>();

            services.AddScoped<IRestaurantesApp, RestaurantesApp>();
            services.AddScoped<IRestaurantesRepositorio, RestaurantesRepositorio>();
            services.AddScoped<IRestaurantesServico, RestaurantesServico>();

            services.AddScoped<IVotacoesApp, VotacoesApp>();
            services.AddScoped<IVotacoesRepositorio, VotacoesRepositorio>();
            services.AddScoped<IVotacoesServico, VotacoesServico>();
        }

        private void RegistrarAutoMapper(IServiceCollection services)
        {
            AutoMapping autoMapping = new AutoMapping();
            var config = autoMapping.Configuracao();
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void RegistrarAcessoSeguro(IServiceCollection services)
        {
            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });
        }
    }
}