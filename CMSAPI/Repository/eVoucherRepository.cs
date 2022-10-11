using CMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMSAPI.Repository
{
    public class eVoucherRepository : IeVoucherRepository
    {
        private readonly db_cmsContext _context;
        public eVoucherRepository()
        {
            _context = new db_cmsContext();
        }
        public eVoucherRepository(db_cmsContext context)
        {
            _context = context;
        }
        public IEnumerable<Evouncher> GetAll()
        {
            return _context.Evouncher.ToList();
        }
        public Evouncher GetById(int EmployeeID)
        {
            return _context.Evouncher.Find(EmployeeID);
        }
        public void Insert(Evouncher employee)
        {
            _context.Evouncher.Add(employee);
        }
        public void Update(Evouncher employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Delete(int EmployeeID)
        {
            Evouncher employee = _context.Evouncher.Find(EmployeeID);
            _context.Evouncher.Remove(employee);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
