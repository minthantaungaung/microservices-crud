using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMSAPI.Models
{
    public partial class Evouncher
    {
        public Evouncher()
        {
            Payment = new HashSet<Payment>();
            Promocode = new HashSet<Promocode>();
        }

        public int EVouncherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Image { get; set; }
        public string Amount { get; set; }
        public byte? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }

        public virtual User AddedByNavigation { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Promocode> Promocode { get; set; }
    }
}
