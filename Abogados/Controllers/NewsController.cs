using Lawyers.Contract.Entities;
using Lawyers.Contract.Interfaces;
using Lawyers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Abogados.Controllers
{
    public class NewsController : Controller
    {
        private INewService service;

        public NewsController(INewService service)
        {
            this.service = service;
        }
        // GET: News
        public ActionResult Index()
        {
            //ViewBag.Mensaje = service.NewsList();

            return View(service.NewsList());
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Date,Title,Body")]NewsModel noticia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Create(noticia);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(noticia);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
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

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
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
