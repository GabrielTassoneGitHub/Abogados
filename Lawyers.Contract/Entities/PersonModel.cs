using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class PersonModel
    {

        public int PersonId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(160)]
        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public DocTypeModel DocType { get; set; }

        [Required]
        [Range(3000000, 100000000)]
        [DisplayName("Numero de documento")]
        public int DocNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Teléfono / Celular")]
        public string PhoneNumber { get; set; }

        [DisplayName("País")]
        public string Nationality { get; set; }

        [DisplayName("Provincia")]
        public string Province { get; set; }

        [DisplayName("Ciudad")]
        public string City { get; set; }

        [DisplayName("Genero")]
        public string Genre { get; set; }

        
        [DisplayName("Profesion")]
        public ProfessionModel Profession { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }
    }
}
