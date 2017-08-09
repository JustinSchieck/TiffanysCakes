namespace TiffanysCakesV4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flavour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flavour()
        {
            CakeFlavours = new HashSet<CakeFlavour>();
            Cakes = new HashSet<Cake>();
        }

        public string FlavourId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CakeFlavour> CakeFlavours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cake> Cakes { get; set; }
    }
}
