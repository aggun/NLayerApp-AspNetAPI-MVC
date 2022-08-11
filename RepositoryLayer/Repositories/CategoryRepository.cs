using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, CoreLayer.Repositories.ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
