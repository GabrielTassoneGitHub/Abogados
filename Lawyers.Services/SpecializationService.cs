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

        public SpecializationModel Edit(int idEspecializacion)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var especializacion = db.Specializations.FirstOrDefault(x => x.SpecializationId == idEspecializacion);
                SpecializationModel _especializacion = new SpecializationModel()
                {
                    SpecializationId = especializacion.SpecializationId,
                    Name = especializacion.Name,
                    Description = especializacion.Description,
                };
                return _especializacion;
            }
        }

        public bool Edit(int idEspecializacion, SpecializationModel s)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                try
                {
                    var especializacion = db.Specializations.FirstOrDefault(x => x.SpecializationId == idEspecializacion);
                    especializacion.Description = s.Description;
                    especializacion.Name = s.Name;
                    especializacion.SpecializationId = s.SpecializationId;
                    db.SaveChanges();
                    return true;
                }
                catch 
                {

                    return false;
                }
                
            }
        }

        public SpecializationModel FirstSpecialization()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var primera = db.Specializations.First();
                SpecializationModel especializacion = new SpecializationModel()
                {
                    SpecializationId = primera.SpecializationId,
                    Name = primera.Name,
                    Description = primera.Description,
                };
                return especializacion;
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

        public void Delete(int idEspecializacion)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var especializacion = db.Specializations.FirstOrDefault(x => x.SpecializationId == idEspecializacion);                
                db.Specializations.Remove(especializacion);
                db.SaveChanges();
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
