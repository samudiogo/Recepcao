using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Web.ViewModels;
using static DPGERJ.Recepcao.Web.AutoMapper.AutoMapperConfig;

namespace DPGERJ.Recepcao.Web.Controllers
{
    public class DestinoController : Controller
    {

        private readonly IDestinoAppService _destinoAppService;

        public DestinoController(IDestinoAppService destinoAppService)
        {
            _destinoAppService = destinoAppService;
        }

        // GET: Destino
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<Destino>, IEnumerable<DestinoViewModel>>(_destinoAppService.GetAll());

            return View(model);
        }

        // GET: Destino/Details/5
        public ActionResult Detalhes(int id)
        {
            var model = Mapper.Map<Destino, DestinoViewModel>(_destinoAppService.GetById(id));

            return View(model);
        }

        // GET: Destino/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Destino/Cadastro
        [HttpPost]
        public ActionResult Cadastro([Bind(Include = "Nome, Andar")]DestinoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var destino = Mapper.Map<DestinoViewModel, Destino>(model);

                _destinoAppService.Create(destino);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // GET: Destino/Editar/5
        public ActionResult Editar(int id)
        {
            var destino = _destinoAppService.GetById(id);
            if (destino == null) return RedirectToAction("Index");

            var model = Mapper.Map<Destino, DestinoViewModel>(destino);

            return View(model);
        }

        // POST: Destino/Editar/5
        [HttpPost]
        public ActionResult Editar([Bind(Include = "Id,Nome,Andar")] DestinoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {

                //TODO SAMUEL
                var destino = _destinoAppService.GetById(model.Id);
                if (destino == null) throw new Exception("Registro não encontrado.");
                destino.Nome = model.Nome;
                destino.Andar = model.Andar;
                _destinoAppService.Update(destino);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destino/Excluir/5
        public ActionResult Excluir(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var dbDestino = _destinoAppService.GetById(id.Value);
            if (dbDestino == null) return HttpNotFound();
            return View(Mapper.Map<Destino, DestinoViewModel>(dbDestino));
        }

        // POST: Destino/Excluir/5
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var destino = _destinoAppService.GetById(id);
            if (destino == null) return HttpNotFound("destino não cadastrado");
            _destinoAppService.Remove(destino);
            return RedirectToAction("Index");
        }

        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _destinoAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}
