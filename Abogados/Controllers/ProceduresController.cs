using Lawyers.Contract.Entities;
using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Abogados.Controllers
{
    public class ProceduresController : Controller
    {
        private IProcedureService service;
        private IPersonService servicePersonas;
        public ProceduresController(IProcedureService service, IPersonService servicePersonas)
        {
            this.service = service;
            this.servicePersonas = servicePersonas;
        }

        // GET: Procedures
        
        public ActionResult Index()
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName,"Employees"))
            {
                var idAbogado = service.BuscarIdAbogado();
                return View(service.ListaTramitesPorAbogado(idAbogado));
            }
            else
            {
                if (Roles.IsUserInRole(WebSecurity.CurrentUserName,"Clients"))
                {
                    var cliente = service.BuscarIdCliente();
                    return View(service.ListaTramitesPorCliente(cliente));
                }
                else
                {
                    return View(service.ProceduresList());
                }
            }
            
        }

        // GET: Procedures/Create
        [Authorize(Roles = "Employees")]
        public ActionResult Create()
        {
            var idAbogado = service.BuscarIdAbogado();
            ProcedureModel tramite = new ProcedureModel() { LawyerId = idAbogado };
            return View(tramite);
        }

        // POST: Procedures/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "LawyerId, ClientId, Topic, Description")]ProcedureModel tramite)
        {
            try
            {
                var IdCliente = service.BuscarClientePorDNI(tramite.ClientId);
                tramite.ClientId = IdCliente;
                
                if (ModelState.IsValid == true)
                {
                    service.Create(tramite);
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
                else
                {
                    return View(tramite);
                }
                
            }
            catch (SystemException ex)
            {
                return View();
            }
        }

        // GET: Procedures/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Procedures/Edit/5
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

        // GET: Procedures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Procedures/Delete/5
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
