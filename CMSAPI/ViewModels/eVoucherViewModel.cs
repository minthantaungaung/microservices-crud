using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI.ViewModels
{
    public class eVoucherViewModel
    {
        public int EVouncherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Image { get; set; }
        public string Amount { get; set; }
        public byte? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }
    }
}
