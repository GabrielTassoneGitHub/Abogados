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
    public class ProfessionService : IProfessionService
    {
        public List<ProfessionModel> ProfessionsList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var profesiones = db.Professions.Select(x => new ProfessionModel()
                {
                    ProfessionId = x.ProfessionId,
                    Name = x.Name,
                    Description = x.Description,                    
                }).ToList();

                return profesiones;
            }
        }

        public string Profesion(int IdProfesion)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var profesion = db.Professions.Where(x => x.ProfessionId == IdProfesion).Select(x => x.Name).SingleOrDefault();
                
                return profesion;
            }
        }
    }
}
