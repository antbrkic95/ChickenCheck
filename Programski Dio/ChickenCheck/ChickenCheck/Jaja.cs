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
    
    public partial class Jaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jaja()
        {
            this.UnositeljJaja = new HashSet<UnositeljJaja>();
        }
    
        public int idDnevneSerije { get; set; }
        public string klasa { get; set; }
        public int brojPrikupljenih { get; set; }
        public System.DateTime datumPrikupljanja { get; set; }
        public bool zapisNekativan { get; set; }
    
        public virtual KokosiTurnus KokosiTurnus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnositeljJaja> UnositeljJaja { get; set; }
    }
}
