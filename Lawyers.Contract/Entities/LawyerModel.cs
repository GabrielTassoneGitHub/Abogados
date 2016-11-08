using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class LawyerModel : PersonModel
    {
        public int LawyerId { get; set; }        

        
        public SpecializationModel Specialization { get; set; }
    }
}
