﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using StockExchange.Service;

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
        private StockExhangeServiceManager stockExhangeServiceManager;
        public StockExchangeService()
        {
            stockExhangeServiceManager = new StockExhangeServiceManager();
        }

        [WebMethod]
        public List<Stock> GetAllStock()
        {
            return stockExhangeServiceManager.GetAllStock().ToList();
        }

        public double GetStockPrice(string stockCode)
        {
            return stockExhangeServiceManager.GetStockPrice(stockCode);
        }
    }
}