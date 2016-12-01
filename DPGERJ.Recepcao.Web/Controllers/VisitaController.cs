using System.Linq;
using System.Net;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Web.ViewModels;
using static DPGERJ.Recepcao.Web.AutoMapper.AutoMapperConfig;

namespace DPGERJ.Recepcao.Web.Controllers
{
    public class VisitaController : Controller
    {
        private readonly IVisitaAppService _visitaAppService;
        private readonly IAssistidoAppService _assistidoAppService;
        private readonly IDestinoAppService _destinoAppService;

        public VisitaController(IVisitaAppService visitaAppService, IAssistidoAppService assistidoAppService,
            IDestinoAppService destinoAppService)
        {
            _assistidoAppService = assistidoAppService;
            _visitaAppService = visitaAppService;
            _destinoAppService = destinoAppService;
        }

        // GET: Visita
        public ActionResult Index()
        {
            var visita =
                Mapper.Map<IEnumerable<Visita>, IEnumerable<VisitaViewModel>>(
                    _visitaAppService.VisitasDoDia(DateTime.Today));
            return View(visita.ToList());
        }

        // GET: Visita/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visita = _visitaAppService.GetById(id.Value);

            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<VisitaViewModel>(visita));
        }

        // GET: Visita/Cadastro
        [HttpGet]
        public ActionResult Cadastro(string documento)
        {
            if (string.IsNullOrEmpty(documento.Trim())) return RedirectToActionPermanent("Cadastro", "Assistido");

            var visitante = _assistidoAppService.GetByDocument(documento);
            if (visitante == null) return RedirectToActionPermanent("Cadastro", "Assistido", new { documento });

            

            var model =
                Mapper.Map<VisitaViewModel>(new Visita
                {
                    AssistidoId = visitante.Id,
                    Assistido = visitante,
                    PessoaMotivo = visitante.Visitas.LastOrDefault()?.PessoaMotivo
                });

            ViewBag.DestinoId = new SelectList(_destinoAppService.GetAll(), "DestinoId", "Nome",
                visitante.Visitas.LastOrDefault()?.DestinoId);
            return View(model);
        }

        // POST: Visita/Casdastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "Id,PessoaMotivo,AssistidoId,DestinoId")] VisitaViewModel model)
        {
            ViewBag.DestinoId = new SelectList(_destinoAppService.GetAll(), "DestinoId", "Nome", model.DestinoId);
            if (!ModelState.IsValid) return View(model);

            try
            {
                model.DataCadastro = DateTime.Now;
                var dbModel = Mapper.Map<Visita>(model);
                _visitaAppService.Create(dbModel);



            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);

                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: Visita/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visita = _visitaAppService.GetById(id.Value);
            if (visita == null)
            {
                return HttpNotFound();
            }

            //ViewBag.DestinoId = new SelectList(_visitaAppService.Destino, "DestinoId", "Nome", visita.DestinoId);
            return View(Mapper.Map<VisitaViewModel>(visita));
        }

        // POST: Visita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,PessoaMotivo,DataCadastro,AssistidoId,DestinoId")] VisitaViewModel visita)
        {
            if (ModelState.IsValid)
            {
                _visitaAppService.Update(Mapper.Map<Visita>(visita));
                return RedirectToAction("Index");
            }
            //ViewBag.AssistidoId = new SelectList(_visitaAppService.Assistido, "Id", "Nome", visita.AssistidoId);
            //ViewBag.DestinoId = new SelectList(_visitaAppService.Destino, "DestinoId", "Nome", visita.DestinoId);
            return View(visita);
        }

        // GET: Visita/Delete/5
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visita = _visitaAppService.GetById(id.Value);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visita/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var visita = _visitaAppService.GetById(id);
            _visitaAppService.Remove(visita);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _visitaAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}
