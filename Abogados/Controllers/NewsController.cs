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
            var noticia = service.Edit(id);

            return View(noticia);
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "NewsId,Title,Body,Date")]NewsModel noticia)
        {
            try
            {
                // TODO: Add update logic here
                service.Edit(id, noticia);

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
            var noticia = service.Edit(id);
            return View(noticia);
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NewsModel noticia)
        {
            try
            {                
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
