using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
