namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Number
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill_Number()
        {
            Bill_attribute = new HashSet<Bill_attribute>();
            Product_Attribute = new HashSet<Product_Attribute>();
            Purchase_Credits = new HashSet<Purchase_Credits>();
            Shop_Debtor_Account = new HashSet<Shop_Debtor_Account>();
        }

        [Key]
        public int Bill_ID { get; set; }

        [Column("Bill_Number")]
        [StringLength(50)]
        public string Bill_Number1 { get; set; }

        [StringLength(50)]
        public string Salesman_Name { get; set; }

        public int? Shop_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_attribute> Bill_attribute { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Attribute> Product_Attribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase_Credits> Purchase_Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop_Debtor_Account> Shop_Debtor_Account { get; set; }
    }
}
