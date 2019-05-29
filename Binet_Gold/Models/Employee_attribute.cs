namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee_attribute
    {
        [Key]
        public int Employee_attribute_ID { get; set; }

        [StringLength(100)]
        public string Particular { get; set; }

        public int? Employee { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        [Column(TypeName = "money")]
        public decimal? Remaining { get; set; }

        public int? Date { get; set; }

        public int? Shop_name { get; set; }

        public virtual Date_Time Date_Time { get; set; }

        public virtual Employee_Details Employee_Details { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
