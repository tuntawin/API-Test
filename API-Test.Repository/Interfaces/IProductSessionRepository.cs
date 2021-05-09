using API_Test.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Test.Repository.Interfaces
{
    public interface IProductSessionRepository
    {
        Task<Product> GetProductById(int id);
        Task<IList<Product>> GetAll();
        Task<int> AddProduct(Product session);
        int UpdateProduct(Product session);
        Task<int> DeleteProduct(int id);
    }
}
