namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cash_Book
    {
        public int Cash_bookID { get; set; }

        [StringLength(50)]
        public string Particular { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debit { get; set; }

        [Column(TypeName = "money")]
        public decimal? credit { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
