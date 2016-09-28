using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abogados.Models;

namespace Abogados.Controllers
{
    public class LawyersController : Controller
    {
        // GET: Lawyers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abogados()
        {
            return View(new LawyerModel { PersonId = 1 });
        }

        [HttpPost]
        public ActionResult Abogados(LawyerModel abogado)
        {
            var abogado1 = abogado;

            return RedirectToAction("Index");
        }
    }
}