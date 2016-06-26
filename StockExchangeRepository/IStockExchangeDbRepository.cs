using System.Collections.Generic;
using StockExchangeDataModel;
using StockExchangeRepository.Model;

namespace StockExchange.Service
{
    public interface IStockExchangeDbRepository
    {
        IList<DbStock> GetAllStocks();
        double GetStockPrice(string stockCode);
        bool Logon(string userName, string password);
        bool SignUp(User newUser);
        bool CreatePortfolio(Portfolio newPortfolio);
    }
   
}