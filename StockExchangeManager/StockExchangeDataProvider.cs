using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockExchange.Service;
using StockExchangeRepository.Model;

namespace StockExchange
{
    public class StockExchangeDataProvider : IStockExchangeDataProvider
    {
        private IStockExchangeDbRepository stockExchangeDbRepository;
        public StockExchangeDataProvider(IStockExchangeDbRepository stockExchangeDbRepository)
        {
            this.stockExchangeDbRepository = stockExchangeDbRepository;
        }
        public IList<Stock> GetAllStock()
        {
            IList<Stock> allStocks = new List<Stock>();

            var dbStocks = stockExchangeDbRepository.GetAllStocks();
            MapDbStockToStock(dbStocks, allStocks);
            return allStocks;
        }

        public double GetStockPrice(string stockCode)
        {
            return stockExchangeDbRepository.GetStockPrice(stockCode);
        }

        public bool Logon(string userName, string password)
        {
            return stockExchangeDbRepository.Logon(userName, password);
        }

        private void MapDbStockToStock(IList<DbStock> dbStocks, IList<Stock> stocks)
        {
            foreach (var dbStock in dbStocks)
            {
                stocks.Add(new Stock
                {
                    Code = dbStock.Code,
                    Price = dbStock.Price,
                    Id = dbStock.Id,
                    Name = dbStock.Name
                });
            }
        }
    }
}
