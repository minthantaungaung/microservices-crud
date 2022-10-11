using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMSAPI.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public int? AmountRecieved { get; set; }
        public string DiscountPercentage { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? SecurityCode { get; set; }
        public int? CustomerId { get; set; }
        public int? VouncherId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Evouncher Vouncher { get; set; }
    }
}
