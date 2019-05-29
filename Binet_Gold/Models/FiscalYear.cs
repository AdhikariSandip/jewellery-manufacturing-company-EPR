namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FiscalYear")]
    public partial class FiscalYear
    {
        [Key]
        public int Fiscal_ID { get; set; }

        [StringLength(50)]
        public string Fisccal_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_to { get; set; }

        public int? Shop_name { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
