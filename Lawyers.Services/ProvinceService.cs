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
    public class ProvinceService : IProvinceService
    {
        public List<ProvinceModel> ProvincesList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var provincias = db.Provinces.Select(x => new ProvinceModel()
                {
                    ProvinceId = x.ProvinceId,                  
                    Name = x.Name,
                }).ToList();

                return provincias;
            }
        }
    }
}
