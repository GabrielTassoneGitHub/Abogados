using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class StateModel
    {
        public int StateId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Name { get; set; }

        [Display(Name = "")]
        public string Description { get; set; }
    }
}
