namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Attribute
    {
        public int Product_attributeID { get; set; }

        public int? Product_Purchase_record { get; set; }

        public string P_Code { get; set; }

        public double? Quality { get; set; }

        public double? Net_Weight { get; set; }

        public double? Westages { get; set; }

        public double? Total_weight { get; set; }

        [Column(TypeName = "money")]
        public decimal? Wages { get; set; }

        public int? Product_ID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Diamond_Stone { get; set; }

        public double? Rate { get; set; }

        public bool? Sold_OrNot { get; set; }

        public int? Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Bikri_Date { get; set; }

        public int? Client_ID { get; set; }

        public int? Bill_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Purchase_Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Bill_Number Bill_Number { get; set; }

        public virtual Client Client { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Product Product { get; set; }

        public virtual Product_Purchase_Record Product_Purchase_Record1 { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
