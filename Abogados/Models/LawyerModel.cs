using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Abogados.Models
{
    public class LawyerModel:PersonModel
    {
        public int LawyerId { get; set; }

        [Required]
        public ProfessionModel Profession { get; set; }

        [Required]
        public SpecializationModel Specialization { get; set; }
    }
}