using API_Test.Repository;
using API_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.Services.Tests
{
    public class ProductServicesTest : TestContext
    {
        [Fact]
        public async void GetProductByIdTest_Return_Product()
        {
            //Arrange
            var productRepo = new ProductSessionRepository(DbContext);
            var productService = new ProductServices(productRepo);
            
            var productId = 5;
            string expectedName = "Chef Anton's Gumbo Mix _ Test";

            //Act
            var actual = await productService.GetProduct(productId);

            //Assert
            Assert.Equal(expectedName, actual.ProductName);
        }

        [Fact]
        public async void GetSumStrockPrice_Return_SumPriceInStock()
        {
            //Arrange
            var productRepo = new ProductSessionRepository(DbContext);
            var productService = new ProductServices(productRepo);

            var productId = 4;
            decimal expectedResult = 1166;

            //Act
            var actual = await productService.GetSumStrockPrice(productId);

            //Assert
            Assert.Equal(expectedResult, actual);
        }
    }
}
