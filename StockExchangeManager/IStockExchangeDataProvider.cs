using System.Collections.Generic;

namespace StockExchange
{
    public interface IStockExchangeDataProvider
    {
        IList<Stock> GetAllStock();
        double GetStockPrice(string stockCode);
        bool Logon(string userName, string password);
    }
}