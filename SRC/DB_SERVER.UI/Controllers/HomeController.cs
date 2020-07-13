using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DB_SERVER.UI.Models;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;

namespace DB_SERVER.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVotacoesApp _votacoesApp;

        public HomeController(ILogger<HomeController> logger, IVotacoesApp votacoesApp)
        {
            _logger = logger;
            _votacoesApp = votacoesApp;
        }

        public IActionResult Index()
        {
            VotacoesViewModel restauranteDoDia = _votacoesApp.ObterRestauranteVencedorParaDia(DateTime.Now);
            
            ViewBag.RestauranteDoDia = restauranteDoDia!=null ? restauranteDoDia.Restaurante.Nome:"Nenhum restaurante votado hoje!";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
