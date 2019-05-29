namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Journal_Voucher
    {
        [Key]
        public int Journal_ID { get; set; }

        public int? Date { get; set; }

        public int? Shop_Name { get; set; }

        [StringLength(150)]
        public string Particular { get; set; }

        public int? Account { get; set; }

        [StringLength(50)]
        public string Ledger_Folio { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Credit { get; set; }

        public virtual Account Account1 { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
