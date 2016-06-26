using System.Collections.Generic;
using StockExchangeRepository.Model;

namespace StockExchange.Service
{
    public interface IStockExchangeDbRepository
    {
        IList<DbStock> GetAllStocks();
        double GetStockPrice(string stockCode);
        bool Logon(string userName, string password);
    }
   
}