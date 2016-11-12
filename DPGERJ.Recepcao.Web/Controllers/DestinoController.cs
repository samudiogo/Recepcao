using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Web.ViewModels;

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
            var destinos = _destinoAppService.GetAll();
            var model = destinos?.Select(destinoDb => new DestinoViewModel
            {
                Id = destinoDb.DestinoId,
                Nome = destinoDb.Nome,
                Andar = destinoDb.Andar

            });
            return View(model);
        }

        // GET: Destino/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var destino = new Destino { Andar = model.Andar, Nome = model.Nome };

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
            return View();
        }

        // POST: Destino/Editar/5
        [HttpPost]
        public ActionResult Editar([Bind(Include = "Id,Nome,Andar")] DestinoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
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
            return View(new DestinoViewModel { Id = dbDestino.DestinoId, Andar = dbDestino.Andar, Nome = dbDestino.Nome });
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
