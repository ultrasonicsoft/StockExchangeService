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
                new DbStock {Id = 1, Code = "INFY", Name = "Infosys", Price = 3200.55},
                new DbStock {Id = 1, Code = "REL", Name = "Reliance", Price = 2400.22},
                new DbStock {Id = 1, Code = "WIPRO", Name = "Wipro", Price = 1200.33},
                new DbStock {Id = 1, Code = "BHEL", Name = "Bharat Petrolium", Price = 230.44}
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
                return double.MinValue;
            }
            return stock.Price;
        }

        public bool Logon(string userName, string password)
        {
            return userName.Equals("balram") && password.Equals("balram");
        }

        public bool SignUp(User newUser)
        {
            return true;
        }

        public bool CreatePortfolio(Portfolio newPortfolio)
        {
            return true;
        }

        public List<Portfolio> GetAllPortfolios(string userName)
        {
            List<Portfolio> allPortfolios = new List<Portfolio>
            {
                new Portfolio
                {
                    Name = "Portfolio-1",
                    Id = 1,
                    StockIds = new List<int> { 1,2 },
                    UserId = "balram"
                },
                new Portfolio
                {
                    Name = "Portfolio-2",
                    Id = 2,
                    StockIds = new List<int> { 1,2,3,4 },
                    UserId = "balram"
                }
            };
            return allPortfolios;
        }

        public List<Stock> GetPortfolioDetails(int portfolioId)
        {
            var stocksInPortfolio = new List<Stock>
           {
               new Stock
               {
                   Code = "INFY",
                   Id = 1,
                   Name = "Infosys",
                   Price = 3200.55
               },
                new Stock
               {
                   Code = "REL",
                   Id = 2,
                   Name = "Reliance",
                   Price = 2400.22
               },
           };
            return stocksInPortfolio;
        }
    }
}