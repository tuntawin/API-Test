using API_Test.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Services.Interfaces
{
    public interface IProductServices
    {
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<int> DeleteProduct(int id);
        Task<decimal> GetSumStrockPrice(int ProductId);
    }
}
