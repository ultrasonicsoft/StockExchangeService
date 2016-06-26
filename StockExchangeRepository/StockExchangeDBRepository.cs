using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockExchangeDataModel;
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
            var stockPrice = double.MinValue;
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

        public bool Logon(string userName, string password)
        {
            bool isAuthenticated = false;
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Username", userName),
                    new KeyValuePair<string, object>("@Password", password),

                };
                var result = dbManager.ExecuteProcedure("IsAuthenticatedUser", parameters);
                if (result.Tables[0].Rows.Count != 0)
                {
                    var dbResult = result.Tables[0].Rows[0][0].ToString();
                    bool.TryParse(dbResult, out isAuthenticated);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return isAuthenticated;
        }

        public bool SignUp(User newUser)
        {
            var userCreated = false;
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Username", newUser.UserName),
                    new KeyValuePair<string, object>("@Password", newUser.Password),
                    new KeyValuePair<string, object>("@Role", "User"),
                    new KeyValuePair<string, object>("@Email", newUser.Email),

                };
                var result = dbManager.ExecuteProcedure("CreateNewUser", parameters);
                userCreated = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return userCreated;
        }

        public bool CreatePortfolio(Portfolio newPortfolio)
        {
            bool hasNewPortfolioCreated = false;
            try
            {
                var newPortfolioId  = CreateNewPortfolio(newPortfolio);
                AddStocksInNewPortfolio(newPortfolioId, newPortfolio);
                hasNewPortfolioCreated = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return hasNewPortfolioCreated;
        }

        public List<Portfolio> GetAllPortfolios(string userName)
        {
            var allPortfolios = new List<Portfolio>();
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@UserName", userName)
                };
                var result = dbManager.ExecuteProcedure("GetAllPortfolios", parameters);

                if (result.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        allPortfolios.Add(new Portfolio
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Name = row["Name"].ToString()
                        });
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return allPortfolios;
        }

        public List<Stock> GetPortfolioDetails(int portfolioId)
        {
            var portfolioDetails = new List<Stock>();
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@PortfolioId", portfolioId)
                };
                var result = dbManager.ExecuteProcedure("GetPortfolioDetails", parameters);

                if (result.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        portfolioDetails.Add(new Stock
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Name = row["Name"].ToString(),
                            Code = row["Code"].ToString(),
                            Price = double.Parse(row["Price"].ToString())
                        });
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return portfolioDetails;
        }

        private int CreateNewPortfolio(Portfolio newPortfolio)
        {
            var newPortfolioId = 0;
            try
            {
                IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Username", newPortfolio.UserId),
                    new KeyValuePair<string, object>("@Name", newPortfolio.Name)
                };
                var result = dbManager.ExecuteProcedure("CreatePortfolio", parameters);

                if (result.Tables[0].Rows.Count != 0)
                {
                    var dbResult = result.Tables[0].Rows[0][0].ToString();
                    int.TryParse(dbResult, out newPortfolioId);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return newPortfolioId;
        }

        private void AddStocksInNewPortfolio(int newPortfolioId, Portfolio newPortfolio)
        {
            try
            {
                foreach (var stockId in newPortfolio.StockIds)
                {
                    IList<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("@PortfolioId", newPortfolioId),
                            new KeyValuePair<string, object>("@StockId", stockId)
                        };
                    var result = dbManager.ExecuteProcedure("AddStocksInPortfolio", parameters);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
