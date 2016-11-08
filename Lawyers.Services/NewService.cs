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
    public class NewService : INewService
    {
        public void Create(NewsModel Noticia)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                db.News.Add(new News()
                {
                    NewsId = Noticia.NewsId,
                    Date = DateTime.Now,
                    Title = Noticia.Title,
                    Body = Noticia.Body,
                });
                db.SaveChanges();
            }
        }

        public List<NewsModel> NewsList()
        {
            using (LawyersConnection db = new LawyersConnection())
            {

                //var nombre = db.Cities.Where(x => x.CityId == 1).Select(x => x.Name).SingleOrDefault();

                var noticias = db.News.Select(x => new NewsModel()
                {
                    NewsId = x.NewsId,
                    Date = x.Date,
                    Title = x.Title,
                    Body = x.Body,
                }).ToList();

                return noticias;

            }

        }
    }
}
