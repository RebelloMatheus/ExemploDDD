using DB_SERVER.Aplicacao.Interfaces;
using DB_SERVER.Aplicacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DB_SERVER.UI.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly IProfissionaisApp _profissionaisApp;
        public ProfissionaisController(IProfissionaisApp profissionaisApp)
        {
            _profissionaisApp = profissionaisApp;
        }
        // GET: ProfissionaisController
        public ActionResult Index()
        {
            return View(_profissionaisApp.Listar());
        }

        // GET: ProfissionaisController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_profissionaisApp.ObterPorId(id));
        }

        // GET: ProfissionaisController/Create
        public ActionResult Create()
        {
            return View(new ProfissionaisViewModel());
        }

        // POST: ProfissionaisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfissionaisViewModel profissional)
        {
            try
            {
                _profissionaisApp.Adicionar(profissional);
                if (profissional.Validacoes.Any())
                {
                    foreach (var item in profissional.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    return View(profissional);
                }

                return RedirectToAction("Index", "Profissionais");
            }
            catch
            {
                return View(profissional);
            }
        }

        // GET: ProfissionaisController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_profissionaisApp.ObterPorId(id));
        }

        // POST: ProfissionaisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfissionaisViewModel profissional)
        {
            try
            {
                _profissionaisApp.Atualizar(profissional);
                if (profissional.Validacoes.Any())
                {
                    foreach (var item in profissional.Validacoes)
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);

                    return View(profissional);
                }

                return RedirectToAction("Index", "Profissionais");
            }
            catch
            {
                return View(profissional);
            }
        }

        // GET: ProfissionaisController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_profissionaisApp.ObterPorId(id));
        }

        // POST: ProfissionaisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProfissionaisViewModel profissional)
        {
            try
            {
                _profissionaisApp.Remover(profissional);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(profissional);
            }
        }
    }
}