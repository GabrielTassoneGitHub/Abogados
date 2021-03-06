﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class SpecializationModel
    {
        public int SpecializationId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Nombre especializacion")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }
    }
}
