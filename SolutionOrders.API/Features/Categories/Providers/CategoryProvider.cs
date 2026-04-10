using Microsoft.EntityFrameworkCore;
using SolutionOrders.API.Models;
using SolutionOrders.API.Models.Data;

namespace SolutionOrders.API.Features.Categories.Providers
{
    public class CategoryProvider(ApplicationDbContext context) : ICategoryProvider
    {
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            var query = context.Categories
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .OrderBy(item => item.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            var query = context.Categories
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var item = await query
                .FirstOrDefaultAsync(i => i.IdCategory == id && i.IsActive, cancellationToken);

            return item ?? throw new KeyNotFoundException($"Kategoria o ID {id} nie istnieje");
        }
    }
}