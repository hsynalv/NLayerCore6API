using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Repository.Efcore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Efcore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(NLayerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetProductWithCategoryAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
