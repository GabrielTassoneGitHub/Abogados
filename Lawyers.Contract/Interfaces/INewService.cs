using Lawyers.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Interfaces
{
    public interface INewService
    {
        List<NewsModel> NewsList();

        void Create(NewsModel Noticia);

        NewsModel Edit(int idNoticia);

        bool Edit(int id, NewsModel noticia);

        void Delete(int idNoticia);



    }
}
