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
        public ActionResult Index()
        {
            return View(service.SpecializationsList());
        }

        // GET: Specializations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Specializations/Create
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Specializations/Edit/5
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

        // GET: Specializations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Specializations/Delete/5
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
    }
}
