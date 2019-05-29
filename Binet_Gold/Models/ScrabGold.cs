namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScrabGold")]
    public partial class ScrabGold
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScrabGold()
        {
            Bill_attribute = new HashSet<Bill_attribute>();
        }

        [Key]
        public int ScrabGold_ID { get; set; }

        public double? Scrab_Gold_Weight { get; set; }

        public double? BuyPercent { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public int? Shop_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_attribute> Bill_attribute { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
