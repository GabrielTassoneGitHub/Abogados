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
    public class SpecializationService : ISpecializationService
    {
        public void Create(SpecializationModel Especializacion)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Specializations.Add(new Specialization()
                {
                    SpecializationId = Especializacion.SpecializationId,
                    Name = Especializacion.Name,
                    Description = Especializacion.Description                    
                });
                db.SaveChanges();
            }
        }

        

        public List<SpecializationModel> SpecializationsList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {              

                var especializaciones = db.Specializations.Select(x => new SpecializationModel()
                {
                    SpecializationId = x.SpecializationId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();

                return especializaciones;

            }
        }

        /*public void Edit(SpecializationModel Especializacion)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                //db.Cities.Where(x => x.CityId == 1).Select(x => x.Name).SingleOrDefault();
                //db.Specializations.Find(Especializacion.SpecializationId);

            }
        }*/
    }
}
