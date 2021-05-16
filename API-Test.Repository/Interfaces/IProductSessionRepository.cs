using API_Test.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Test.Repository.Interfaces
{
    public interface IProductSessionRepository
    {
        Task<Product> GetById(int id);
        Task<IList<Product>> GetAll();
        Task<int> Add(Product session);
        int Update(Product session);
        Task<int> Delete(int id);
    }
}
