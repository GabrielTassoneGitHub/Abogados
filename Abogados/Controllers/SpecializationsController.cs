using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abogados.Models;

namespace Abogados.Controllers
{
    public class SpecializationsController : Controller
    {
        // GET: Specializations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Especializaciones()
        {
            return View(new SpecializationModel { SpecializationId = 1 });
        }

        [HttpPost]
        public ActionResult Especializaciones(SpecializationModel especializacion)
        {
            var especializacion1 = especializacion;

            return RedirectToAction("Index");
        }
    }
}