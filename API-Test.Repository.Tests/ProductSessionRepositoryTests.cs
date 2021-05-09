using API_Test.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace API_Test.Repository.Tests
{
    [TestClass]
    public class ProductSessionRepositoryTests : NORTHWNDContextTest
    {
        [TestMethod]
        public async Task GetProductById_TestAsync()
        {
            //Arrange
            //var dbContext = CreateDbContext();
            var productSessionRepository = new ProductSessionRepository(DbContext);
            int productId = 5;
            string productName = "Chef Anton's Gumbo Mix _ Test";
            //Act
            var result = await productSessionRepository.GetProductById(productId);

            //Assert
            Assert.AreEqual(productId, result.ProductId);
            Assert.AreEqual(productName, result.ProductName);

            //Clean up
            DbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteProduct_TestAsync()
        {
            //Arrange
            //var dbContext = CreateDbContext();
            var productSessionRepository = new ProductSessionRepository(DbContext);
            int productId = 78;

            //Act
            await productSessionRepository.DeleteProduct(productId);

            var result = await productSessionRepository.GetProductById(productId);

            //Assert
            Assert.IsTrue(result == null);

            //Clean up
            DbContext.Dispose();
        }
    }
}
