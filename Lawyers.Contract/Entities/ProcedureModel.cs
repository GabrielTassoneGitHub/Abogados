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
        public ProcedureModel()
        {
            this.StateId = 1;
        }
        public int ProcedureId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Tema")]
        public string Topic { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required]
        public int LawyerId { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int StateId { get; set; }
    }
}
