using Lawyers.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abogados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(EmailModel email)
        {
            var correo = new Correos();
            correo.EnviarEmail(email.From, email.Password, email.To, email.Body, email.Subject);

            return RedirectToAction("Index");
        }

       
    }
}