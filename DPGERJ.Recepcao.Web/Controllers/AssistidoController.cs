using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Web.ViewModels;
using static DPGERJ.Recepcao.Web.AutoMapper.AutoMapperConfig;


namespace DPGERJ.Recepcao.Web.Controllers
{
    public class AssistidoController : Controller
    {
        private readonly IAssistidoAppService _assistidoAppService;

        public AssistidoController(IAssistidoAppService assistidoAppService)
        {
            _assistidoAppService = assistidoAppService;
        }
        // GET: Assistido
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<Assistido>, IEnumerable<AssistidoViewModel>>
                (_assistidoAppService.ListaTopAssistidosRecentes());


            var modelAlternativa = _assistidoAppService.ListaTopAssistidosRecentes().Select(assistido => new AssistidoViewModel
            {
                Id = assistido.Id,
                Nome = assistido.Nome,
                OrgaoEmissor = assistido.OrgaoEmissor,
                Documento = assistido.Documento,
                ImagemUrl = assistido.ImagemUrl
            });


            return View(model);
        }

        // GET: Assistido/Details/5
        public ActionResult Details(string documento)
        {
            if (string.IsNullOrEmpty(documento)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //var assistido = _assistidoAppService.GetById(id.Value);
            var assistido = Mapper.Map<Assistido, AssistidoViewModel>(_assistidoAppService.GetByDocument(documento));

            if (assistido == null) return HttpNotFound();

            return View(assistido);
        }

        // GET: Assistido/Cadastro
        public ActionResult Cadastro(string documento = null) => View(new AssistidoViewModel { Documento = documento });



        // POST: Assistido/Cadastro

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "Id,Nome,Documento,OrgaoEmissor,ImagemUrl,cadastraVisita")] AssistidoViewModel assistido, bool cadastraVisita)
        {
            if (ModelState.IsValid)
            {
                var name = $"{Guid.NewGuid().ToString("N")}.jpg";
                var local = Server.MapPath(Url.Content(@"~/Content/fotos/"));
                var filePathName = Path.Combine(local + name);
                using (var fs = new FileStream(filePathName, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        var imgData = Convert.FromBase64String(assistido.ImagemUrl);
                        bw.Write(imgData);
                    }
                }
                assistido.ImagemUrl = name;

                _assistidoAppService.Create(Mapper.Map<AssistidoViewModel, Assistido>(assistido));

                return cadastraVisita ? RedirectToAction("Cadastro", "Visita", new { assistido.Documento }) : RedirectToAction("Index");
            }

            return View(assistido);
        }

        [HttpPost]
        public JsonResult UploadImagem(HttpPostedFileBase fileToUpload)
        {
            if (fileToUpload == null) return Json("erro", JsonRequestBehavior.DenyGet);
            var name = Guid.NewGuid().ToString("N") + Path.GetExtension(fileToUpload.FileName);
            var local = Server.MapPath(Url.Content(@"~/Content/fotos"));
            fileToUpload.SaveAs(Path.Combine(local) + name);
            return Json($"{name}.jpg");

        }
        // GET: Assistido/Editar/5
        public ActionResult Editar(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var assistido = _assistidoAppService.GetById(id.Value);

            if (assistido == null) return HttpNotFound();
            var model = new AssistidoViewModel
            {
                Id = assistido.Id,
                Nome = assistido.Nome,
                Documento = assistido.Documento,
                OrgaoEmissor = assistido.OrgaoEmissor,
                ImagemUrl = assistido.ImagemUrl
            };
            return View(model);
        }

        // POST: Assistido/Editar/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nome,Documento,OrgaoEmissor,ImagemUrl")] AssistidoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var assistido = _assistidoAppService.GetById(model.Id);
            if (assistido == null) return HttpNotFound();
            assistido.Nome = model.Nome;
            assistido.Documento = model.Documento;
            assistido.OrgaoEmissor = model.OrgaoEmissor;
            assistido.ImagemUrl = model.ImagemUrl;

            _assistidoAppService.Update(assistido);
            return RedirectToAction("Index");
        }

        // GET: Assistido/Excluir/5
        public ActionResult Excluir(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var assistido = _assistidoAppService.GetById(id.Value);

            if (assistido == null) return HttpNotFound();

            var model = new AssistidoViewModel
            {
                Id = assistido.Id,
                Nome = assistido.Nome,
                Documento = assistido.Documento,
                OrgaoEmissor = assistido.OrgaoEmissor,
                ImagemUrl = assistido.ImagemUrl
            };


            return View(model);
        }

        // POST: Assistido/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var assistido = _assistidoAppService.GetById(id);
            if (assistido == null) return HttpNotFound("assistido não cadastrado");
            _assistidoAppService.Remove(assistido);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _assistidoAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}
