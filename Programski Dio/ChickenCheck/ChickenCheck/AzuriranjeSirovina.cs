//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChickenCheck
{
    using System;
    using System.Collections.Generic;
    
    public partial class AzuriranjeSirovina
    {
        public int idZapisa { get; set; }
        public System.DateTime datum { get; set; }
        public decimal kolicina { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Sirovina Sirovina { get; set; }
    }
}
