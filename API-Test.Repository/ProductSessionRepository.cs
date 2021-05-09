using API_Test.Database.Models;
using API_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Repository
{
    public class ProductSessionRepository : IProductSessionRepository
    {
        private readonly NORTHWNDContext _context;

        public ProductSessionRepository(NORTHWNDContext context)
        {
            _context = context;
        }

        public async Task<int> AddProduct(Product session)
        {
            _context.Products.Add(session);
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return 0;
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;           
        }

        public int UpdateProduct(Product session)
        {
            _context.Entry(session).State = EntityState.Modified;
            return _context.SaveChanges();
        }

    }
}
