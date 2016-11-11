using Lawyers.Contract.Entities;
using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abogados.Controllers
{
    public class SpecializationsController : Controller
    {
        private ISpecializationService service;

        public SpecializationsController(ISpecializationService service)
        {
            this.service = service;
        }

        // GET: Specializations
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(service.SpecializationsList());
        }


        // GET: Specializations/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specializations/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Description")]SpecializationModel especializacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Create(especializacion);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(especializacion);
                }
                // TODO: Add insert logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: Specializations/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id)
        {
            var especializacion = service.Edit(id);

            return View(especializacion);
        }

        // POST: Specializations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,[Bind(Include = "SpecializationId,Name,Description")]SpecializationModel especializacion)
        {
            try
            {
                // TODO: Add update logic here
                service.Edit(id, especializacion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Specializations/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id)
        {
            var especializacion = service.Edit(id);
            return View(especializacion);
        }

        // POST: Specializations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SpecializationModel especializacion)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
