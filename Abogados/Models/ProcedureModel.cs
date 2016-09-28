using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Abogados.Models
{
    public class ProcedureModel
    {
        public int ProcedureId { get; set; }

        [Required]        
        public ClientModel Client { get; set; }
    }
}