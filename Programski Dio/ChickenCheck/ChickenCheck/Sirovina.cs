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
    
    public partial class Sirovina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sirovina()
        {
            this.AzuriranjeSirovina = new HashSet<AzuriranjeSirovina>();
            this.Recept = new HashSet<Recept>();
            this.Recept1 = new HashSet<Recept>();
        }
    
        public int idSirovine { get; set; }
        public string nazivSirovine { get; set; }
        public decimal kolicina { get; set; }
        public string opis { get; set; }
        public bool zapisNeaktivan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AzuriranjeSirovina> AzuriranjeSirovina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recept> Recept { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recept> Recept1 { get; set; }
    }
}
