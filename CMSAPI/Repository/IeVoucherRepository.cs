using CMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMSAPI.Repository
{
    public interface IeVoucherRepository
    {
        IEnumerable<Evouncher> GetAll();
        Evouncher GetById(int vocherID);
        void Insert(Evouncher vocher);
        void Update(Evouncher vocher);
        void Delete(int vocherID);
        void Save();
        void Dispose();
    }
}
