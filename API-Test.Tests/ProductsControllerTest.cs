using API_Test.Controllers;
using API_Test.Database.Models;
using API_Test.Repository;
using API_Test.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.Tests
{
    public class ProductsControllerTest : TestHelper
    {
        [Fact]
        public async void GetProductByIdTest_Return_OkResult()
        {
            //Arrange
            var repository = new ProductSessionRepository(DbContext);
            var controller = new ProductsController(repository);
            var productId = 5;
            string expectedName = "Chef Anton's Gumbo Mix _ Test";

            //Act
            var data = await controller.GetProduct(productId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(data.Result);
            var product = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(expectedName, product.ProductName);
        }

        [Fact]
        public async void DeleteProductByIdTest_Return_OkResult()
        {
            //Arrange
            var repository = new ProductSessionRepository(DbContext);
            var controller = new ProductsController(repository);
            var productId = 78;

            //Act
            var data = await controller.DeleteProduct(productId);

            //Assert
            _ = Assert.IsType<OkResult>(data);
        }
    }
}
