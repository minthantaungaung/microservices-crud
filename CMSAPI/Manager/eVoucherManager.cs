using CMSAPI.Models;
using CMSAPI.Repository;
using CMSAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI.Manager
{
    public class eVoucherManager
    {
        db_cmsContext ctx = new db_cmsContext();
        private eVoucherRepository _eVoucherRepository;
        public eVoucherManager()
        {
            _eVoucherRepository = new eVoucherRepository(new db_cmsContext());
        }
        public eVoucherManager(IeVoucherRepository eVoucherRepository)
        {
            _eVoucherRepository = (eVoucherRepository)eVoucherRepository;
        }
        public IEnumerable<Evouncher> UpSertEVoucher(Evouncher evouncher)
        {

            var isExited = ctx.Evouncher.Where(x => x.EVouncherId == evouncher.EVouncherId).FirstOrDefault();
            if (isExited != null)
            {
                isExited.Title = evouncher.Title;
                isExited.Description = evouncher.Description;
                isExited.ExpiryDate = evouncher.ExpiryDate;
                isExited.Image = evouncher.Image;
                isExited.Amount = evouncher.Amount;
                isExited.ActiveStatus = 1;
            }
            else
            {
                ctx.Evouncher.Add(evouncher);
            }
            ctx.SaveChanges();
            return ctx.Evouncher.ToList();
        }
        public Evouncher SetAsInactive(int ID)
        {
            var result = ctx.Evouncher.Where(x => x.EVouncherId == ID).FirstOrDefault();
            result.ActiveStatus = 0;
            ctx.SaveChanges();
            return result;
        }

        public bool AddEmployee(Evouncher model)
        {
            _eVoucherRepository.Insert(model);
            _eVoucherRepository.Save();
            return true;
        }
    }
}
