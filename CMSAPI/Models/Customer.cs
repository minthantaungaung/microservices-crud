using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMSAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Payment = new HashSet<Payment>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string LoginId { get; set; }
        public string GiftedBy { get; set; }
        public int? GiftLimit { get; set; }
        public int? BuyLimit { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
