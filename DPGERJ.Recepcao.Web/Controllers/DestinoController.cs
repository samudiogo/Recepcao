using System.Linq;
using System.Web.Mvc;
using DPGERJ.Recepcao.Application.Interfaces;
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
                Id = destinoDb.Id,
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

        // GET: Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destino/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destino/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Destino/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destino/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Destino/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
