namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Purchase_Credits
    {
        [Key]
        public int Purchase_CreditID { get; set; }

        public int? Bill_Number { get; set; }

        public int? Product_purchase_record { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total_Amount { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Bill_Number Bill_Number1 { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Product_Purchase_Record Product_Purchase_Record1 { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
