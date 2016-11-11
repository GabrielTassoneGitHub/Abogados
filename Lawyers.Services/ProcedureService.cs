using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;
using Lawyers.DataAccess;
using WebMatrix.WebData;

namespace Lawyers.Services
{
    public class ProcedureService : IProcedureService
    {
        public string BuscarAbogado(int idAbogado)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var abogado = db.Lawyers.Where(x => x.LawyerId == idAbogado).Select(x => x.Person.Name).SingleOrDefault();
                return abogado;
            }
        }

        public string BuscarCliente(int documento)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var cliente = db.Clients.Where(x => x.Person.DocNumber == documento).Select(x => x.Person.LastName).SingleOrDefault();
                return cliente;
            }
        }

        public int BuscarClientePorDNI(int documento)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var cliente = db.Clients.Where(x => x.Person.DocNumber == documento).Select(x => x.ClientId).FirstOrDefault();
                return cliente;
            }
        }

        public int BuscarIdAbogado()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var persona = db.Persons.Where(x => x.UserId == WebSecurity.CurrentUserId).Select(x => x.PersonId).SingleOrDefault();

                var IdAbogado = db.Lawyers.Where(x => x.PersonId == persona).Select(x => x.LawyerId).SingleOrDefault();
                
                return IdAbogado;
            }
        }
        public int BuscarIdCliente()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var persona = db.Persons.Where(x => x.UserId == WebSecurity.CurrentUserId).Select(x => x.PersonId).SingleOrDefault();

                var idCliente = db.Clients.Where(x => x.PersonId == persona).Select(x => x.ClientId).SingleOrDefault();

                return idCliente;
            }
        }

        public string BuscarEstado(int estado)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var nombreEstado = db.States.Where(x => x.StateId == estado).Select(x => x.Name).SingleOrDefault();
                return nombreEstado;
            }
        }

        public void Create(ProcedureModel Tramite)
        {

            using (LawyersConnection db = new LawyersConnection())
            {

                db.Procedures.Add(new Procedure()
                {
                    ProcedureId = Tramite.ProcedureId,
                    Topic = Tramite.Topic,
                    Description = Tramite.Description,
                    ClientId = Tramite.ClientId,
                    LawyerId = Tramite.LawyerId,
                    StateId = Tramite.StateId,
                });
                db.SaveChanges();
            }
        }

        public List<ProcedureModel> ProceduresList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var tramites = db.Procedures.Select(x => new ProcedureModel()
                {
                    ProcedureId = x.ProcedureId,
                    Topic = x.Topic,
                    ClientId = x.ClientId,
                    LawyerId = x.LawyerId,
                    StateId = x.StateId,                    
                    Description = x.Description,
                }).ToList();

                return tramites;
            }
        }

        public List<ProcedureModel> ListaTramitesPorAbogado(int idAbogado)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var tramites = db.Procedures.Where(x => x.LawyerId == idAbogado).Select(x => new ProcedureModel()
                {
                    ProcedureId = x.ProcedureId,
                    Topic = x.Topic,
                    ClientId = x.ClientId,
                    LawyerId = x.LawyerId,
                    StateId = x.StateId,
                    Description = x.Description,
                }).ToList();

                return tramites;
            }
        }

        public List<ProcedureModel> ListaTramitesPorCliente(int idCliente)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var tramites = db.Procedures.Where(x => x.ClientId == idCliente).Select(x => new ProcedureModel()
                {
                    ProcedureId = x.ProcedureId,
                    Topic = x.Topic,
                    ClientId = x.ClientId,
                    LawyerId = x.LawyerId,
                    StateId = x.StateId,
                    Description = x.Description,
                }).ToList();

                return tramites;
            }
        }

    }
}
