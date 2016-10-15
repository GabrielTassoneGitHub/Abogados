using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;

namespace Lawyers.Services
{
    public class NewService : INewService
    {
        public List<NewsModel> NewsList()
        {
            var prueba = new NewsModel();
            var pruebas = new List<NewsModel>();
            pruebas.Add(prueba);

            return pruebas;
        }
    }
}
