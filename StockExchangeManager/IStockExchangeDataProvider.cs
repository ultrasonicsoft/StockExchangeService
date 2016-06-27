using System.Collections.Generic;
using StockExchangeDataModel;

namespace StockExchange
{
    public interface IStockExchangeDataProvider
    {
        IList<Stock> GetAllStock();
        double GetStockPrice(string stockCode);
        bool Logon(string userName, string password);
    }
}