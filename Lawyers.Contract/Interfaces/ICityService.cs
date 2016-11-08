using Lawyers.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Interfaces
{
    public interface ICityService
    {
        List<CityModel> CitiesList(); //Lista de todas las ciudades

        List<CityModel> CitiesByProvinceList(int Provincia); //Lista de ciudades de una provincia

       
    }
}
