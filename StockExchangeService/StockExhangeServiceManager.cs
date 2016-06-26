using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using StockExchange.Service;
using StockExchangeDataModel;

namespace StockExchange
{
    internal class StockExhangeServiceManager
    {
        private readonly IStockExchangeDataProvider stockExchangeDataProvider;
        private IStockExchangeDbRepository stockExchangeDbRepository;
        private string dbConnectionString;

        internal StockExhangeServiceManager()
        {
            dbConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=StockExchangeDb; Trusted_Connection=True;";
            stockExchangeDbRepository = new StockExchangeDbRepository(dbConnectionString);
            stockExchangeDataProvider = new StockExchangeDataProvider(stockExchangeDbRepository);
        }

        internal IList<Stock> GetAllStock()
        {
            IList<Stock> allStocks = new List<Stock>();
            try
            {
                allStocks = stockExchangeDataProvider.GetAllStock();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return allStocks;
        }

        public double GetStockPrice(string stockCode)
        {
            return stockExchangeDataProvider.GetStockPrice(stockCode);
        }

        public bool Logon(string userName, string password)
        {
            return stockExchangeDataProvider.Logon(userName, password);
        }

        public bool SignUp(User newUser)
        {
            return stockExchangeDbRepository.SignUp(newUser);
        }

        public bool CreatePortfolio(Portfolio newPortfolio)
        {
            return stockExchangeDbRepository.CreatePortfolio(newPortfolio);
        }
    }
}