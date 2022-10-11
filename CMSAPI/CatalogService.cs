using CMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI
{
    public class CatalogService : ICatalogService
    {
        public List<Category> FindAll()
        {
            return new List<Category>
            {
                new Category {ID ="c1", Name="Category 1"},
                new Category {ID ="c2", Name="Category 2"},
                new Category {ID ="c3", Name="Category 3"},
                new Category {ID ="c4", Name="Category 4"},
            };
        }
    }
}
