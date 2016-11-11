using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abogados.Models;
using Lawyers.Contract.Entities;
using Lawyers.Contract.Interfaces;
using WebMatrix.WebData;
using System.Web.Security;

namespace Abogados.Controllers
{
    public class PersonController : Controller
    {
       
        private IDocTypeService serviceTiposDoc;
        private ICityService serviceCiudades;
        private IProvinceService serviceProvincias;
        private IPersonService servicePersonas;
        private IProfessionService serviceProfesiones;
        private ISpecializationService serviceEspecializaciones;
        

        public PersonController(ISpecializationService serviceEspecializaciones, IDocTypeService serviceTiposDoc, ICityService serviceCiudades, IProvinceService serviceProvincias, IPersonService servicePersonas, IProfessionService serviceProfesiones)
        {
            this.serviceTiposDoc = serviceTiposDoc;
            this.serviceCiudades = serviceCiudades;
            this.serviceProvincias = serviceProvincias;
            this.servicePersonas = servicePersonas;
            this.serviceProfesiones = serviceProfesiones;
            this.serviceEspecializaciones = serviceEspecializaciones;
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
                            var nuevoAbogado = servicePersonas.InstanciaAbogado(persona);
                            nuevoAbogado.Specialization = serviceEspecializaciones.FirstSpecialization();                                                
                            servicePersonas.Create(nuevoAbogado);
                            Roles.AddUserToRole(WebSecurity.CurrentUserName, "Employees");                          
                            break;

                        case "Contador":
                            var nuevoContador = servicePersonas.InstanciaContador(persona);
                            servicePersonas.Create(nuevoContador);
                            Roles.AddUserToRole(WebSecurity.CurrentUserName, "Employees");
                            break;

                        case "Administrador de RRHH":
                            var nuevoAdminRRHH = servicePersonas.InstanciaAdminRRHH(persona);
                            servicePersonas.Create(nuevoAdminRRHH);
                            Roles.AddUserToRole(WebSecurity.CurrentUserName, "Employees");
                            break;

                        case "Secretaria":
                            var nuevaSecretaria = servicePersonas.InstanciaSecretaria(persona);
                            servicePersonas.Create(nuevaSecretaria);
                            Roles.AddUserToRole(WebSecurity.CurrentUserName, "Administrator");
                            break;

                    }        
                    if (profession == "Abogado")
                    {
                        return RedirectToAction("CompleteRegistration", "Person");
                    }    
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }        
                        
                }
                else
                {
                    return View(persona);
                }
            }
            catch
            {
                ViewBag.Errores = "Se produjo un error en la carga de sus datos";
                return View();
            }
        }

        //GET: Person/CompleteRegistration
        public ActionResult CompleteRegistration()
        {
            ViewBag.Specializations = serviceEspecializaciones.SpecializationsList();
            return View();
        }

        //POST: Person/CompleteRegistration
        [HttpPost]
        public ActionResult CompleteRegistration([Bind(Include = "Specialization")]LawyerModel Abogado)
        {
            ViewBag.Specializations = serviceEspecializaciones.SpecializationsList();
            try
            {
                if (ModelState.IsValid == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(Abogado);
                }
            }
            catch
            {
                return View();
            }

        }



        // GET: Person/Edit/5
        [Authorize(Roles ="Employees,Administrator")]
        public ActionResult Edit()
        {
            ViewBag.Profession = serviceProfesiones.ProfessionsList();
            var abogadoAEditar = servicePersonas.EditLawyer();
            return View(abogadoAEditar);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,LastName,BirthDate,Nationality,Province,City,Genre,PhoneNumber,Description,Profession")]PersonModel personaAEditar)
        {
            try
            {
                ViewBag.Profession = serviceProfesiones.ProfessionsList();
                var abogadoAEditar = servicePersonas.InstanciaAbogado(personaAEditar);
                servicePersonas.EditLawyer(personaAEditar.PersonId, abogadoAEditar);

                return RedirectToAction("Index","Home");
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
