namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rate")]
    public partial class Rate
    {
        [Key]
        public int Rate_ID { get; set; }

        [StringLength(50)]
        public string Particular { get; set; }

        [Column(TypeName = "money")]
        public decimal? Bikri_Dar { get; set; }

        [Column(TypeName = "money")]
        public decimal? Kharid_Dar { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
