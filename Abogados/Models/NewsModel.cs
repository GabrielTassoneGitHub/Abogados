using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abogados.Models
{
    public class NewsModel
    {
        public int NewsId { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}