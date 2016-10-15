using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class NewsModel
    {
        public int NewsId { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
