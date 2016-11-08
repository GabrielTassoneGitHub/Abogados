using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Titulo")]        
        public string Title { get; set; }

        [Required]
        [Display(Name = "Cuerpo")]
        public string Body { get; set; }
    }
}
