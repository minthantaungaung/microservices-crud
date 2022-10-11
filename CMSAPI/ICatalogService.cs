using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI.Models
{
    public interface ICatalogService
    {
        List<Category> FindAll();
    }
}
