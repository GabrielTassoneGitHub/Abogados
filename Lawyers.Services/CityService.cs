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
    public class CityService : ICityService
    {
        public List<CityModel> CitiesByProvinceList(int Provincia)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var ciudadesProv = db.Cities.Where(x => x.ProvinceId == Provincia).Select(x => new CityModel()
                {
                    CityId = x.CityId,
                    Name = x.Name,
                }).ToList();

                return ciudadesProv;
            }
        }

        public List<CityModel> CitiesList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                
                var ciudades = db.Cities.Select(x => new CityModel()
                {
                    CityId = x.CityId,
                    Name = x.Name,
                }).ToList();

                return ciudades;
            }
        }

        
    }
}
