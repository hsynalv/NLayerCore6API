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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NLayerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetCategoryByIdWithProductAsync(int id)
        {
            return await _context.Categories.Include(x => x.Products).Where(I => I.Id == id).SingleOrDefaultAsync();
        }
    }
}
