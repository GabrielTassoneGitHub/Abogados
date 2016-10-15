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
        public ClientModel Client { get; set; }
    }
}
