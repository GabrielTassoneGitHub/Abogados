//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lawyers.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administrator
    {
        public int AdministratorId { get; set; }
        public int PersonId { get; set; }
    
        public virtual Person Person { get; set; }
    }
}