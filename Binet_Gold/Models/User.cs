namespace Binet_Gold.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int Users_ID { get; set; }

        [StringLength(150)]
        public string Username { get; set; }

        [StringLength(150)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public int? Shop_name { get; set; }

        public virtual Shop_Details Shop_Details { get; set; }
    }
}
