namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Bill_attribute = new HashSet<Bill_attribute>();
            Gold_Issue = new HashSet<Gold_Issue>();
            Product_Attribute = new HashSet<Product_Attribute>();
            Shop_Debtor_Account = new HashSet<Shop_Debtor_Account>();
        }

        [Key]
        public int Client_ID { get; set; }

        [StringLength(50)]
        public string Client_name { get; set; }

        [StringLength(50)]
        public string Client_Address { get; set; }

        [StringLength(20)]
        public string Phone_number { get; set; }

        public string Client_Code { get; set; }

        public int? Shop_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_attribute> Bill_attribute { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gold_Issue> Gold_Issue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Attribute> Product_Attribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop_Debtor_Account> Shop_Debtor_Account { get; set; }
    }
}
