using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class ProcedureModel
    {
        public int ProcedureId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Tema")]
        public string Topic { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required]
        public LawyerModel Lawyer { get; set; }

        [Required]
        public ClientModel Client { get; set; }

        public StateModel State { get; set; }
    }
}
