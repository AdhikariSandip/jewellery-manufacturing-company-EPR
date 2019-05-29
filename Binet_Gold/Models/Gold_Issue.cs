namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gold_Issue
    {
        public int Gold_IssueID { get; set; }

        [StringLength(100)]
        public string Particular { get; set; }

        public double? Weight { get; set; }

        public double? Order_Weight { get; set; }

        public double? Rate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Return_Date { get; set; }

        public double? Return_Prod_Weight { get; set; }

        public double? Return_tukraSun { get; set; }

        public double? Lost_Sun { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lost_amount { get; set; }

        public bool? Order_OrNot { get; set; }

        [Column(TypeName = "money")]
        public decimal? Wages { get; set; }

        public int? NumberOfItems_Received { get; set; }

        public int? Employee_ID { get; set; }

        public int? Client { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Employee_Details Employee_Details { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
