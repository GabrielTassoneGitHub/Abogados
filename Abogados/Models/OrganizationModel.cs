using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abogados.Models
{
    public class OrganizationModel
    {
        //ver si dejar o no esta entidad. 

        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Mission { get; set; }

        public string Vision { get; set; }

        public string History { get; set; }


    }
}