namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_attribute
    {
        public int Bill_attributeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Paid_amount { get; set; }

        public double? Rate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        public int? Client_ID { get; set; }

        public int? Bill_NumID { get; set; }

        public int? ScrabGold_ID { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Bill_Number Bill_Number { get; set; }

        public virtual Client Client { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual ScrabGold ScrabGold { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
