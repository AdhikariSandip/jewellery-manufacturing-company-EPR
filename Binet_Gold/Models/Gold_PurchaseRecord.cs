namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gold_PurchaseRecord
    {
        [Key]
        public int GP_ID { get; set; }

        [StringLength(50)]
        public string Vendor_name { get; set; }

        public double? Weight { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? Paid { get; set; }

        [Column(TypeName = "money")]
        public decimal? Remaining { get; set; }

        public int? Shop_name { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
