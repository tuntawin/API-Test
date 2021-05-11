using API_Test.Database.Models;
using API_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.Repository.Tests
{
    public class ProductSessionRepositoryTests : NORTHWNDContextTest
    {
        [Fact]
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
            Assert.Equal(productId, result.ProductId);
            Assert.Equal(productName, result.ProductName);

            //Clean up
            DbContext.Dispose();
        }

        [Fact]
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
            Assert.True(result == null);

            //Clean up
            DbContext.Dispose();
        }
    }
}
