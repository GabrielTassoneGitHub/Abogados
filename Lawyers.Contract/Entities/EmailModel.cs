using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Contract.Entities
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        [EmailAddress]
        public string To { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
