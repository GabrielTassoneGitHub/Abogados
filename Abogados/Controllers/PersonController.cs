using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abogados.Models;
using Lawyers.Contract.Entities;
using Lawyers.Contract.Interfaces;
using WebMatrix.WebData;

namespace Abogados.Controllers
{
    public class PersonController : Controller
    {
       
        private IDocTypeService serviceTiposDoc;
        private ICityService serviceCiudades;
        private IProvinceService serviceProvincias;
        private IPersonService servicePersonas;
        private IProfessionService serviceProfesiones;
        

        public PersonController(IDocTypeService serviceTiposDoc, ICityService serviceCiudades, IProvinceService serviceProvincias, IPersonService servicePersonas, IProfessionService serviceProfesiones)
        {
            this.serviceTiposDoc = serviceTiposDoc;
            this.serviceCiudades = serviceCiudades;
            this.serviceProvincias = serviceProvincias;
            this.servicePersonas = servicePersonas;
            this.serviceProfesiones = serviceProfesiones;
        }

        // GET: Person
        public ActionResult Index()
        {
            ViewBag.TiposDoc = serviceTiposDoc.DocTypesList();
            var personas = new List<PersonModel>();
            for (int i = 0; i < 10; i++)
            {
                personas.Add(new PersonModel { Name = "Persona " + i });
            }

            return View(personas);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.DocType = serviceTiposDoc.DocTypesList();
            ViewBag.Profession = serviceProfesiones.ProfessionsList();            
            return View();
        }
        
        // POST: Person/Create
        [HttpPost]
        public ActionResult Create([Bind(Include="Name,LastName,DocType,DocNumber,BirthDate,Profession,Nationality,Province,City,Genre,PhoneNumber,Description")]PersonModel persona)
        {
            ViewBag.DocType = serviceTiposDoc.DocTypesList();
            ViewBag.Profession = serviceProfesiones.ProfessionsList();
            try
            {
                if (ModelState.IsValid == true)
                {
                    var profession = serviceProfesiones.Profesion(persona.Profession.ProfessionId);
                    switch(profession)
                    {
                        case "Abogado":
                            var nuevoAbogado = servicePersonas.Instance(persona);                                                    
                            servicePersonas.Create(nuevoAbogado);
                            break;

                        case "Contador Publico":
                            break;

                    }                                  
                    return RedirectToAction("CompleteRegistration","Person");
                }
                else
                {
                    return View(persona);
                }
            }
            catch
            {
                return View();
            }
        }

        //GET: Person/CompleteRegistration
        public ActionResult CompleteRegistration()
        {
            
            return View();
        }

        //POST: Person/CompleteRegistration
        [HttpPost]
        public ActionResult CompleteRegistration([Bind(Include = "Specialization")]LawyerModel Abogado)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }



        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
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

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
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
