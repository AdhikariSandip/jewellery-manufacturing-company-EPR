namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class General_Ledger
    {
        [Key]
        public int GL_ID { get; set; }

        [StringLength(50)]
        public string Ledger_Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Credit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
