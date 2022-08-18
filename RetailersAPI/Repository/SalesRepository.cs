using Retailers.API.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retailers.API.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly RETAILEREntities _context;
        public SalesRepository()
        {
            _context = new RETAILEREntities();
        }
        public SalesRepository(RETAILEREntities context)
        {
            _context = context;
        }

        public IEnumerable<SALE> GetAll()
        {
            return _context.SALES.ToList();
        }

        public IEnumerable<SALE>  GetById(int CustomerID)
        {
            return _context.SALES.ToList().Where( a=> a.Customer_ID == CustomerID);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}