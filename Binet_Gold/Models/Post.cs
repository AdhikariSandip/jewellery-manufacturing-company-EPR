namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Employee_Details = new HashSet<Employee_Details>();
        }

        [Key]
        public int Post_ID { get; set; }

        [StringLength(50)]
        public string Post_Name { get; set; }

        public int? Shop_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Details> Employee_Details { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
