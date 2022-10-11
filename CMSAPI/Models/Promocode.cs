using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMSAPI.Models
{
    public partial class Promocode
    {
        public int PromocodeId { get; set; }
        public string PromoCode1 { get; set; }
        public byte[] Qr { get; set; }
        public int? VouncherId { get; set; }

        public virtual Evouncher Vouncher { get; set; }
    }
}
