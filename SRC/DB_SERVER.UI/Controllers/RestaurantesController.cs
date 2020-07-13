using System;
using System.Linq;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB_SERVER.UI.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly IRestaurantesApp _restaurantesApp;
        public RestaurantesController(IRestaurantesApp restaurantesApp)
        {
            _restaurantesApp = restaurantesApp;
        }
        // GET: RestaurantesController
        public ActionResult Index()
        {
            return View(_restaurantesApp.Listar());
        }

        // GET: RestaurantesController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_restaurantesApp.ObterPorId(id));
        }

        // GET: RestaurantesController/Create
        public ActionResult Create()
        {
            return View(new RestaurantesViewModel());
        }

        // POST: RestaurantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantesViewModel restaurante)
        {
            try
            {
                _restaurantesApp.Adicionar(restaurante);
                if (restaurante.Validacoes.Any())
                {
                    foreach (var item in restaurante.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    return View(restaurante);
                }

                return RedirectToAction("Index", "Restaurantes");
            }
            catch
            {
                return View(restaurante);
            }
        }

        // GET: RestaurantesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_restaurantesApp.ObterPorId(id));
        }

        // POST: RestaurantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestaurantesViewModel restaurante)
        {
            try
            {
                _restaurantesApp.Atualizar(restaurante);
                if (restaurante.Validacoes.Any())
                {
                    foreach (var item in restaurante.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    return View(restaurante);
                }

                return RedirectToAction("Index", "Restaurantes");
            }
            catch
            {
                return View(restaurante);
            }
        }

        // GET: RestaurantesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_restaurantesApp.ObterPorId(id));
        }

        // POST: RestaurantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RestaurantesViewModel restaurante)
        {
            try
            {
                _restaurantesApp.Remover(restaurante);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(restaurante);
            }
        }
    }
}