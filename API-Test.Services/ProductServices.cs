using API_Test.Database.Models;
using API_Test.Repository.Interfaces;
using API_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductSessionRepository  _productRepo;

        public ProductServices(IProductSessionRepository productSessionRepository)
        {
            _productRepo = productSessionRepository;
        }

        public Task<IList<Product>> GetAllProducts()
        {
            try
            {
                return _productRepo.GetAll();
            }
            catch
            {
                //Log and throw
                throw;
            }
        }

        public Task<Product> GetProduct(int id)
        {
            try
            {
                return _productRepo.GetById(id);
            }
            catch
            {
                //Log and throw
                throw;
            }
        }

        public Task<int> DeleteProduct(int id)
        {
            try
            {
                return _productRepo.Delete(id);
            }
            catch
            {
                //Log and throw
                throw;
            }
        }

        public async Task<decimal> GetSumStrockPrice(int ProductId)
        {
            try
            {
                var product = await _productRepo.GetById(ProductId);

                return (product.UnitPrice ?? 0) * (product.UnitsInStock ?? 0);
            }
            catch
            {
                throw;
            }
        }
    }
}
