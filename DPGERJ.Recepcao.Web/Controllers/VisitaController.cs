using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DPGERJ.Recepcao.Web.Controllers
{
    public class VisitaController : Controller
    {
        private readonly IVisitaAppService _visitaAppService;
        private readonly IAssistidoAppService _assistidoAppService;
        private readonly IDestinoAppService _destinoAppService;

        public VisitaController(IVisitaAppService visitaAppService, IAssistidoAppService assistidoAppService, IDestinoAppService destinoAppService)
        {
            _assistidoAppService = assistidoAppService;
            _visitaAppService = visitaAppService;
            _destinoAppService = destinoAppService;
        }

        // GET: Visita
        public ActionResult Index()
        {

            var visita = new List<Visita>(); //_visitaAppService.GetAll();
            return View(visita.ToList());
        }

        // GET: Visita/Details/5
        public ActionResult Details(int? id)
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

        // GET: Visita/Casdastro
        public ActionResult Cadastro( string documento)
        {
            if (string.IsNullOrEmpty(documento.Trim())) return RedirectToActionPermanent("Cadastro", "Assistido");

            var visitante = _assistidoAppService.GetByDocument(documento);
            if (visitante == null) return RedirectToActionPermanent("Cadastro", "Assistido");
            var visita = new Visita { Assistido = visitante, AssistidoId = visitante.Id };


            ViewBag.DestinoId = new SelectList(_destinoAppService.GetAll(), "DestinoId", "Nome");
            return View(visita);
        }

        // POST: Visita/Casdastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "Id,PessoaMotivo,AssistidoId,DestinoId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                visita.DataCadastro = DateTime.Now;
                _visitaAppService.Create(visita);

                return RedirectToAction("Index");
            }

            //ViewBag.AssistidoId = new SelectList(_visitaAppService.Assistido, "Id", "Nome", visita.AssistidoId);
            ViewBag.DestinoId = new SelectList(_destinoAppService.GetAll(), "DestinoId", "Nome");
            return View(visita);
        }

        // GET: Visita/Edit/5
        public ActionResult Edit(int? id)
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
            //ViewBag.AssistidoId = new SelectList(_visitaAppService.Assistido, "Id", "Nome", visita.AssistidoId);
            //ViewBag.DestinoId = new SelectList(_visitaAppService.Destino, "DestinoId", "Nome", visita.DestinoId);
            return View(visita);
        }

        // POST: Visita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PessoaMotivo,DataCadastro,AssistidoId,DestinoId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _visitaAppService.Update(visita);
                return RedirectToAction("Index");
            }
            //ViewBag.AssistidoId = new SelectList(_visitaAppService.Assistido, "Id", "Nome", visita.AssistidoId);
            //ViewBag.DestinoId = new SelectList(_visitaAppService.Destino, "DestinoId", "Nome", visita.DestinoId);
            return View(visita);
        }

        // GET: Visita/Delete/5
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
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
