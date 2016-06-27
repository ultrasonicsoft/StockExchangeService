using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using StockExchange.Service;
using StockExchangeDataModel;

namespace StockExchange
{
    /// <summary>
    /// Summary description for StockExchangeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchangeService : System.Web.Services.WebService
    {
        public AuthSoapHd spAuthenticationHeader;

        private StockExhangeServiceManager stockExhangeServiceManager;
        public StockExchangeService()
        {
            stockExhangeServiceManager = new StockExhangeServiceManager();
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public List<Stock> GetAllStock()
        {
            if (spAuthenticationHeader.strUserName == "TestUser" && spAuthenticationHeader.strPassword == "TestPassword")
            {
                return stockExhangeServiceManager.GetAllStock().ToList();
            }
            return null;
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public double GetStockPrice(string stockCode)
        {
            if (spAuthenticationHeader.strUserName == "TestUser" && spAuthenticationHeader.strPassword == "TestPassword")
            {
                return stockExhangeServiceManager.GetStockPrice(stockCode);
            }
            return 0.0;
        }


        [WebMethod]
        public bool Logon(string userName, string password)
        {
            return stockExhangeServiceManager.Logon(userName, password);
        }

        [WebMethod]
        public bool SignUp(User newUser)
        {
            return stockExhangeServiceManager.SignUp(newUser);
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public bool CreatePortfolio(Portfolio newPortfolio)
        {
            if (spAuthenticationHeader.strUserName == "TestUser" && spAuthenticationHeader.strPassword == "TestPassword")
            {
                return stockExhangeServiceManager.CreatePortfolio(newPortfolio);
            }
            return false;
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public List<Portfolio> GetAllPortfolios(string userName)
        {
            if (spAuthenticationHeader.strUserName == "TestUser" && spAuthenticationHeader.strPassword == "TestPassword")
            {
                return stockExhangeServiceManager.GetAllPortfolios(userName);
            }
            return null;
        }

        [WebMethod, SoapHeader("spAuthenticationHeader")]
        public List<Stock> GetPortfolioDetails(int portfolioId)
        {
            if (spAuthenticationHeader.strUserName == "TestUser" && spAuthenticationHeader.strPassword == "TestPassword")
            {
                return stockExhangeServiceManager.GetPortfolioDetails(portfolioId);
            }
            return null;
        }
    }
}