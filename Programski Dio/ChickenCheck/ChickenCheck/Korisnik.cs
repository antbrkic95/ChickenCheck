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
    
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.AzuriranjeSirovina = new HashSet<AzuriranjeSirovina>();
            this.LogAkcija = new HashSet<LogAkcija>();
            this.UnositeljJaja = new HashSet<UnositeljJaja>();
            this.UnosUginulih = new HashSet<UnosUginulih>();
            this.Funkcionalnost = new HashSet<Funkcionalnost>();
        }
    
        public string ime { get; set; }
        public string prezime { get; set; }
        public int idKorisnika { get; set; }
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public bool zapisNeaktivan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AzuriranjeSirovina> AzuriranjeSirovina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogAkcija> LogAkcija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnositeljJaja> UnositeljJaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnosUginulih> UnosUginulih { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funkcionalnost> Funkcionalnost { get; set; }
    }
}
