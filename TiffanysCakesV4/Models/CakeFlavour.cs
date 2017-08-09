namespace TiffanysCakesV4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CakeFlavour
    {
        public string CakeFlavourId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CakeId { get; set; }

        [Required]
        [StringLength(128)]
        public string FlavourId { get; set; }

        public virtual Cake Cake { get; set; }

        public virtual Flavour Flavour { get; set; }
    }
}
