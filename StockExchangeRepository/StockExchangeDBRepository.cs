using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockExchangeRepository.DbManager;
using StockExchangeRepository.Model;

namespace StockExchange.Service
{
    public class StockExchangeDbRepository : IStockExchangeDbRepository
    {
        private IDbManager dbManager;
        private IList<DbStock> allStocks;
        public StockExchangeDbRepository(string connectionString)
        {
            allStocks = new List<DbStock>();
            this.dbManager = new DbManager(connectionString);
        }
        public IList<DbStock> GetAllStocks()
        {
            var result = dbManager.ExecuteProcedure("GetAllStocks");
            FillStocks(result);
            return allStocks;
        }

        private void FillStocks(DataSet result)
        {
            try
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    allStocks.Add(new DbStock
                    {
                        Code = row["Code"].ToString(),
                        Price = double.Parse(row["Price"].ToString()),
                        Id = int.Parse(row["Id"].ToString()),
                        Name = row["Name"].ToString()
                    });
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public double GetStockPrice(string stockCode)
        {
            var stockPrice = 0.0;
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                    { new KeyValuePair<string, object>("@StockCode", stockCode) };
                var result = dbManager.ExecuteProcedure("GetStockPrice", parameters);
                if (result.Tables[0].Rows.Count != 0)
                {
                    var dbPrice = result.Tables[0].Rows[0][0];
                    double.TryParse(dbPrice.ToString(), out stockPrice);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return stockPrice;
        }
    }
}
