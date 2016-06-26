using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using StockExchangeDataModel;
using StockExchangeRepository.Model;

namespace StockExchange.Service
{
    public class StockExchangeMockRepository : IStockExchangeDbRepository
    {
        private readonly IList<DbStock> allStocks;

        public StockExchangeMockRepository()
        {
            allStocks = new List<DbStock>
            {
                new DbStock {Id = 1, Code = "INFY", Name = "Infosys", Price = 3200},
                new DbStock {Id = 1, Code = "REL", Name = "Reliance", Price = 2400},
                new DbStock {Id = 1, Code = "WIPRO", Name = "Wipro", Price = 1200},
                new DbStock {Id = 1, Code = "BHEL", Name = "Bharat Petrolium", Price = 230}
            };
        }

        public string ConnectionString { get; set; }

        public IList<DbStock> GetAllStocks()
        {
            return allStocks;
        }

        public double GetStockPrice(string stockCode)
        {
            var stock = allStocks.FirstOrDefault(x => x.Code.Equals(stockCode));
            if (stock == null)
            {
                throw new Exception("Invalid stock code provided");
            }
            return stock.Price;
        }

        public bool Logon(string userName, string password)
        {
            return true;
        }

        public bool SignUp(User newUser)
        {
            return true;
        }

        public bool CreatePortfolio(Portfolio newPortfolio)
        {
            return true;
        }
    }
}