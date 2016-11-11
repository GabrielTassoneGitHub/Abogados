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

        public NewsModel Edit(int idNoticia)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var noticia = db.News.FirstOrDefault(x => x.NewsId == idNoticia);
                NewsModel _noticia = new NewsModel()
                {
                    NewsId = noticia.NewsId,
                    Title = noticia.Title,
                    Body = noticia.Body,
                    Date = noticia.Date,
                };
                return _noticia;
            }
        }

        public bool Edit(int idNoticia, NewsModel notic)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                try
                {
                    var noticia = db.News.FirstOrDefault(x => x.NewsId == idNoticia);
                    noticia.Title = notic.Title;
                    noticia.Body = notic.Body;
                    noticia.Date = notic.Date;
                    db.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }

            }
        }

        public void Delete(int idNoticia)
        {
            using (LawyersConnection db = new LawyersConnection())
            {
                var noticia = db.News.FirstOrDefault(x => x.NewsId == idNoticia);
                db.News.Remove(noticia);
                db.SaveChanges();
            }
        }
    }
}
