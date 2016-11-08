using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;
using Lawyers.DataAccess;

namespace Lawyers.Services
{
    public class ProcedureService : IProcedureService
    {
        public void Create(ProcedureModel Tramite)
        {

            using (LawyersConnection db = new LawyersConnection())
            {

                db.Procedures.Add(new Procedure()
                {
                    ProcedureId = Tramite.ProcedureId,
                    Topic = Tramite.Topic,
                    Description = Tramite.Description,
                    ClientId = Tramite.Client.ClientId,
                    LawyerId = Tramite.Lawyer.LawyerId,
                });
                db.SaveChanges();
            }
        }

        public List<ProcedureModel> ProceduresList()
        {
            throw new NotImplementedException();
        }
    }
}
