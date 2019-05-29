namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contract_Persons
    {
        [Key]
        public int CP_ID { get; set; }

        public int? CP_Name { get; set; }

        public int? Shop_name { get; set; }

        public int? Date { get; set; }

        [StringLength(150)]
        public string Particular { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Employee_Details Employee_Details { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
