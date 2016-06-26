using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace StockExchange.Tests
{
    [TestClass()]
    public class StockExchangeDataProviderTests
    {
        StockExchangeService stockExchangeService = new StockExchangeService();

        [TestMethod()]
        public void ShouldReturnStockCount()
        {
            var expectedAllStocksCount = 10;
            var allStocks = stockExchangeService.GetAllStock();
            var actualAllStoccksCount = allStocks.Count;
            Assert.AreEqual(expectedAllStocksCount,actualAllStoccksCount);
        }

        [TestMethod]
        public void ShouldReturnPriceForGivenStockCode()
        {
            var stockCode = "INFY";
            var expectedStockPrice = 3200.55;
            var actualStockPrice = stockExchangeService.GetStockPrice(stockCode);
            Assert.AreEqual(expectedStockPrice, actualStockPrice);
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenInvalidStockCodeIsProvided()
        {
            var expectedStockPrice = 0.0;
            var actualStockPrice = stockExchangeService.GetStockPrice("Invalid");
            Assert.AreEqual(expectedStockPrice, actualStockPrice);

        }

    }
}