using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Abogados.Models
{
    public class PersonModel
    {
        
        public int PersonId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(160)]
        [DisplayName("Apellido")]
        public string LastName { get; set; }        

        [Required]
        public DocTypeModel DocType { get; set; }

        [Required]
        [Range(3000000,100000000)]
        public int DocNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Correo Electrónico")]
        public string E_Mail { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public string Province { get; set; }
       
        public string City { get; set; }

        public string Genre { get; set; }       

        public string Description { get; set; }
    }
}