namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee_Details()
        {
            Contract_Persons = new HashSet<Contract_Persons>();
            Employee_attribute = new HashSet<Employee_attribute>();
            Gold_Issue = new HashSet<Gold_Issue>();
        }

        [Key]
        public int Employee_ID { get; set; }

        public string Employee_Code { get; set; }

        [StringLength(50)]
        public string Employee_Name { get; set; }

        [StringLength(50)]
        public string Employee_Address { get; set; }

        [StringLength(20)]
        public string Employee_PhoneNumber { get; set; }

        [StringLength(50)]
        public string Employee_nationality { get; set; }

        public int? Post { get; set; }

        public int? Shop_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_Persons> Contract_Persons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_attribute> Employee_attribute { get; set; }

        public virtual Post Post1 { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gold_Issue> Gold_Issue { get; set; }
    }
}
