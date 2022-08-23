//using Retailers.API.DAL;
using Retailers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retailers.API.Repository
{
        public interface ISalesRepository
        {
            IEnumerable<SALE> GetAll();
            IEnumerable<SALE> GetById(int CustomerID);
            void Save();
        }
    }
