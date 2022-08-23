using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
//using Retailers.API.DAL;
using Retailers.API.Models;
using Retailers.API.Repository;
using System.Data.Entity;

namespace RetailersAPI.Controllers
{
    public class RewardsController : ApiController
    {

        IDictionary<int, decimal> rewardsPerCustomer = new Dictionary<int, decimal>();
        IDictionary<int, decimal> rewardsPerTransaction = new Dictionary<int, decimal>();

        private ISalesRepository _saleRepository;

        public RewardsController()
        {
            _saleRepository = new SalesRepository(new RETAILEREntities());
        }


        public RewardsController(ISalesRepository salesRepository)
        {
            _saleRepository = salesRepository;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<SALE> index()
        {
            var model = _saleRepository.GetAll();
            return model;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getSalesByCustomer/{customerId}")]
        public IEnumerable<SALE> getSalesByCustomer(int customerID)
        {
            var model = _saleRepository.GetById(customerID);            
            return model;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getrewards/{customerId}")]
        public IDictionary<int, decimal> getrewards(int customerID)
        {
            var model = _saleRepository.GetById(customerID);
            decimal rewards = 0;
            foreach (SALE transaction in model)
            {
                if (transaction.Transaction_value > 50)
                {
                    rewards += (transaction.Transaction_value - 50);
                    if (transaction.Transaction_value > 100)
                    {
                        rewards += (transaction.Transaction_value - 100);
                    }

                }
            }
            rewardsPerCustomer.Add(customerID, rewards);
            return rewardsPerCustomer;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getrewardsPerTransaction/")]
        public IDictionary<int, decimal> getrewardsPerTransaction()
        {
            var model = _saleRepository.GetAll();
            
            foreach (SALE transaction in model)
            {
                decimal rewardsPerTransCalc = 0;
                if (transaction.Transaction_value > 50)
                {
                    rewardsPerTransCalc += (transaction.Transaction_value - 50);
                    if (transaction.Transaction_value > 100)
                    {
                        rewardsPerTransCalc += (transaction.Transaction_value - 100);
                    }

                }
                rewardsPerTransaction.Add(transaction.Transaction_Id, rewardsPerTransCalc);
            }            
            return rewardsPerTransaction;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getrewards/")]
        public IDictionary<int, decimal> getrewards()
        {
            var model = _saleRepository.GetAll();
            IEnumerable<int> customer = model.Select(p => p.Customer_ID).Distinct();
            foreach(int customerId in customer)
            {
                decimal rewardsPerCustomerCalc = 0;
                foreach (SALE transaction in model.Where(p => p.Customer_ID == customerId))
            {
                
                if (transaction.Transaction_value > 50)
                {
                        rewardsPerCustomerCalc += (transaction.Transaction_value - 50);
                    if (transaction.Transaction_value > 100)
                    {
                            rewardsPerCustomerCalc += (transaction.Transaction_value - 100);
                    }

                }
                
            }
                rewardsPerTransaction.Add(customerId, rewardsPerCustomerCalc);
            }
            return rewardsPerTransaction;
        }
    }
}
