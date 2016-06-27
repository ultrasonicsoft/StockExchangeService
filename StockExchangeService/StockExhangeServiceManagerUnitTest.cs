using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange;
using StockExchange.Service;
using StockExchangeDataModel;

namespace StockExchangeServiceUnitTests
{
    [TestClass]
    public class StockExhangeServiceManagerTest
    {
        private StockExhangeServiceManager stockExhangeServiceManager;

        [TestInitialize]
        public void Setup()
        {
            IStockExchangeDbRepository stockExchangeMockRepository = new StockExchangeMockRepository();
            StockExchangeDataProvider stockExchangeDataProvider = new StockExchangeDataProvider(stockExchangeMockRepository);
            stockExhangeServiceManager = new StockExhangeServiceManager(stockExchangeDataProvider, stockExchangeMockRepository);
        }

        [TestMethod()]
        public void ShouldReturnStockCount()
        {
            var expectedAllStocksCount = 4;
            var allStocks = stockExhangeServiceManager.GetAllStock();
            var actualAllStoccksCount = allStocks.Count;
            Assert.AreEqual(expectedAllStocksCount, actualAllStoccksCount);
        }

        [TestMethod]
        public void ShouldReturnPriceForGivenStockCode()
        {
            var stockCode = "INFY";
            var expectedStockPrice = 3200.55;
            var actualStockPrice = stockExhangeServiceManager.GetStockPrice(stockCode);
            Assert.AreEqual(expectedStockPrice, actualStockPrice);
        }

        [TestMethod]
        public void ShouldReturnNegativeInfinityWhenInvalidStockCodeIsProvided()
        {
            var expectedStockPrice = double.MinValue;
            var actualStockPrice = stockExhangeServiceManager.GetStockPrice("Invalid");
            Assert.AreEqual(expectedStockPrice, actualStockPrice);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenValidCredentialsArePassed()
        {
            var isAuthenticated = stockExhangeServiceManager.Logon("balram", "balram");
            Assert.IsTrue(isAuthenticated);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateNewUser()
        {
            var randomUserId = new Random().Next();
            var newUser = new User
            {
                Email = "user" + randomUserId + "@gmail.com",
                Password = "password" + randomUserId,
                UserName = "User" + randomUserId
            };
            var isUserCreated = stockExhangeServiceManager.SignUp(newUser);
            Assert.IsTrue(isUserCreated);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateNewPortfolio()
        {
            var radomPortfolioId = new Random().Next();
            var newPortfolio = new Portfolio
            {
                Name = "Portfolio-" + radomPortfolioId,
                UserId = "balram",
                StockIds = new List<int> { 1, 2 }
            };
            var isNewPortfolioCreated = stockExhangeServiceManager.CreatePortfolio(newPortfolio);
            Assert.IsTrue(isNewPortfolioCreated);
        }


        [TestMethod]
        public void ShouldBeAbleToRetrieveAllPortfolioForLoggedInUser()
        {
            var allPortfolios = stockExhangeServiceManager.GetAllPortfolios("balram");
            CollectionAssert.AllItemsAreNotNull(allPortfolios);
        }


        [TestMethod]
        public void ShouldReturnAllStocksForGivenPortfolio()
        {
            var stocksInPortfolio = stockExhangeServiceManager.GetPortfolioDetails(1);
            CollectionAssert.AllItemsAreNotNull(stocksInPortfolio);
        }
    }
}
