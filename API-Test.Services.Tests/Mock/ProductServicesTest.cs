using API_Test.Database.Models;
using API_Test.Repository;
using API_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.Services.Tests.Mock
{
    public class ProductServicesTest
    {
        public ProductServicesTest()
        {

        }

        //Mock only Repository
        //[Fact]
        //public async void GetProduct_Return_Product()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IProductSessionRepository>();
        //    mockRepo.Setup(repo => repo.GetById(5)).ReturnsAsync(new Product() { ProductId = 5, ProductName = "product 5", UnitPrice = 10 });

        //    int productId = 5;
        //    string expectedName = "product 5";
        //    var services = new ProductServices(mockRepo.Object);

        //    //Act
        //    var result = await services.GetProduct(productId);


        //    // Assert
        //    Assert.Equal(expectedName, result.ProductName);
        //}

        //Mock only Repository
        [Fact]
        public async void GetProduct_Return_Product()
        {
            // Arrange
            var mockRepo = new Mock<IProductSessionRepository>();
            mockRepo.Setup(repo => repo.GetById(5)).ReturnsAsync(new Product() { ProductId = 4, ProductName = "product 4", UnitPrice = 10, UnitsInStock = 5});

            int productId = 5;
            decimal expectedName = 50;
            var services = new ProductServices(mockRepo.Object);

            //Act
            var result = await services.GetSumStrockPrice(productId);


            // Assert
            Assert.Equal(expectedName, result);
        }

        //UseInMemoryDatabase
        //[Fact]
        //public async void GetAllTest_InMemoryDatabase()
        //{
        //    var options = new DbContextOptionsBuilder<NORTHWNDContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDatabase")
        //        .Options;

        //    // Insert seed data into the database using one instance of the context
        //    using (var context = new NORTHWNDContext(options))
        //    {
        //        context.Products.Add(new Product { ProductId = 1, ProductName = "Product 1", UnitPrice = 20, UnitsInStock = 5 });
        //        context.Products.Add(new Product { ProductId = 2, ProductName = "Product 2", UnitPrice = 50, UnitsInStock = 3 });
        //        context.Products.Add(new Product { ProductId = 5, ProductName = "Product 5", UnitPrice = 100, UnitsInStock = 1 });
        //        context.SaveChanges();
        //    }

        //    // Use a clean instance of the context to run the test
        //    using (var context = new NORTHWNDContext(options))
        //    {
        //        IProductSessionRepository productRepo = new ProductSessionRepository(context);
        //        List<Product> products = (List<Product>)await productRepo.GetAll();

        //        Assert.Equal(3, products.Count);
        //    }
        //}
    }
}
