using System;
using System.Linq;
using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DB_SERVER.UI.Controllers
{
    public class VotacoesController : Controller
    {
        private readonly IVotacoesApp _votacoesApp;
        private readonly IRestaurantesApp _restaurantesApp;
        private readonly IProfissionaisApp _profissionaisApp;
        public VotacoesController(IVotacoesApp votacoesApp, IRestaurantesApp restaurantesApp, IProfissionaisApp profissionaisApp)
        {
            _votacoesApp = votacoesApp;
            _restaurantesApp = restaurantesApp;
            _profissionaisApp = profissionaisApp;
        }
        // GET: VotacoesController
        public ActionResult Index()
        {
            return View(_votacoesApp.ListarCompleto());
        }

        // GET: VotacoesController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_votacoesApp.ObterPorId(id));
        }

        // GET: VotacoesController/Create
        public ActionResult Create()
        {
            CarregaViewBagProfissional();
            CarregaViewBagRestaurante();

            return View(new VotacoesViewModel() {Data = DateTime.Now });
        }
        private void CarregaViewBagProfissional()
        {
            ViewBag.ProfissionalId = new SelectList(_profissionaisApp.Listar(), "Id", "Nome");
        }
        private void CarregaViewBagRestaurante()
        {
            ViewBag.RestauranteId = new SelectList(_restaurantesApp.Listar(), "Id", "Nome");
        }
        // POST: VotacoesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VotacoesViewModel votacao)
        {
            try
            {
                votacao=_votacoesApp.Adicionar(votacao);
                if (votacao.Validacoes.Any())
                {
                    foreach (var item in votacao.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    CarregaViewBagProfissional();
                    CarregaViewBagRestaurante();
                    return View(votacao);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                CarregaViewBagProfissional();
                CarregaViewBagRestaurante();
                return View(votacao);
            }
        }

        // GET: VotacoesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            CarregaViewBagProfissional();
            CarregaViewBagRestaurante();
            return View(_votacoesApp.ObterPorId(id));
        }

        // POST: VotacoesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VotacoesViewModel votacao)
        {
            try
            {
                _votacoesApp.Atualizar(votacao);
                if (votacao.Validacoes.Any())
                {
                    foreach (var item in votacao.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    CarregaViewBagProfissional();
                    CarregaViewBagRestaurante();
                    return View(votacao);
                }

                return RedirectToAction("Index", "Votacoes");
            }
            catch
            {
                CarregaViewBagProfissional();
                CarregaViewBagRestaurante();
                return View(votacao);
            }
        }

        // GET: VotacoesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_votacoesApp.ObterPorId(id));
        }

        // POST: VotacoesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VotacoesViewModel votacao)
        {
            try
            {
                _votacoesApp.Remover(votacao);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(votacao);
            }
        }
    }
}