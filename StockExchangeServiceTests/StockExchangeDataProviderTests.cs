using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchange;
using StockExchangeDataModel;

namespace StockExchangeServiceTests
{
    [TestClass()]
    public class StockExchangeDataProviderTests
    {
        StockExchangeService stockExchangeService = new StockExchangeService();

        [TestInitialize]
        public void Setup()
        {
            stockExchangeService.spAuthenticationHeader = new AuthSoapHd
            {
                strUserName = "TestUser",
                strPassword = "TestPassword"
            };
        }
        [TestMethod()]
        public void ShouldReturnStockCount()
        {
            var expectedAllStocksCount = 10;
            var allStocks = stockExchangeService.GetAllStock();
            var actualAllStoccksCount = allStocks.Count;
            Assert.AreEqual(expectedAllStocksCount, actualAllStoccksCount);
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
        public void ShouldReturnNegativeInfinityWhenInvalidStockCodeIsProvided()
        {
            var expectedStockPrice = double.MinValue;
            var actualStockPrice = stockExchangeService.GetStockPrice("Invalid");
            Assert.AreEqual(expectedStockPrice, actualStockPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowExceptionWhenSoapHeaderIsNotProvided()
        {
            stockExchangeService.spAuthenticationHeader = null;
            stockExchangeService.GetAllStock();
        }

        [TestMethod]
        public void ShouldReturnTrueWhenValidCredentialsArePassed()
        {
            var isAuthenticated = stockExchangeService.Logon("balram", "balram");
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
            var isUserCreated = stockExchangeService.SignUp(newUser);
            Assert.IsTrue(isUserCreated);

            var canLoginWithNewUser = stockExchangeService.Logon(newUser.UserName, newUser.Password);
            Assert.IsTrue(canLoginWithNewUser);
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
            var isNewPortfolioCreated = stockExchangeService.CreatePortfolio(newPortfolio);
            Assert.IsTrue(isNewPortfolioCreated);
        }

        [TestMethod]
        public void ShouldBeAbleToRetrieveAllPortfolioForLoggedInUser()
        {
            var allPortfolios = stockExchangeService.GetAllPortfolios("balram");
            CollectionAssert.AllItemsAreNotNull(allPortfolios);
        }

        [TestMethod]
        public void ShouldReturnAllStocksForGivenPortfolio()
        {
            var stocksInPortfolio = stockExchangeService.GetPortfolioDetails(1);
            CollectionAssert.AllItemsAreNotNull(stocksInPortfolio);
        }
    }
}