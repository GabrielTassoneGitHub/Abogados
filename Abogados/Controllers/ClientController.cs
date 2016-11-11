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
    public class ClientController : Controller
    {
        private IDocTypeService serviceTiposDoc;
        private ICityService serviceCiudades;
        private IProvinceService serviceProvincias;
        private IPersonService servicePersonas;
        private IProfessionService serviceProfesiones;
        private ISpecializationService serviceEspecializaciones;
        public ClientController(ISpecializationService serviceEspecializaciones, IDocTypeService serviceTiposDoc, ICityService serviceCiudades, IProvinceService serviceProvincias, IPersonService servicePersonas, IProfessionService serviceProfesiones)
        {
            this.serviceTiposDoc = serviceTiposDoc;
            this.serviceCiudades = serviceCiudades;
            this.serviceProvincias = serviceProvincias;
            this.servicePersonas = servicePersonas;
            this.serviceProfesiones = serviceProfesiones;
            this.serviceEspecializaciones = serviceEspecializaciones;
        }
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        
        public ActionResult Create()
        {
            ViewBag.DocType = serviceTiposDoc.DocTypesList();
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,LastName,DocType,DocNumber,BirthDate,Nationality,Province,City,Genre,PhoneNumber,Description")]ClientModel cliente)
        {
            try
            {
                ViewBag.DocType = serviceTiposDoc.DocTypesList();
                if (ModelState.IsValid == true)
                {
                    var nuevoCliente = servicePersonas.InstanciaCliente(cliente);
                    servicePersonas.Create(nuevoCliente);
                    Roles.AddUserToRole(WebSecurity.CurrentUserName,"Clients");
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(cliente);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        [Authorize(Roles = "Clients")]
        public ActionResult Edit()
        {
            var clienteAEditar = servicePersonas.EditClient();
            return View(clienteAEditar);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,LastName,BirthDate,Nationality,Province,City,Genre,PhoneNumber,Description")]ClientModel clienteAEditar)
        {
            try
            {
                // TODO: Add update logic here
                servicePersonas.EditClient(clienteAEditar.PersonId, clienteAEditar);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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
