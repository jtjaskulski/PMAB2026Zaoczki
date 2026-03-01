using Mapster;
using Microsoft.EntityFrameworkCore;
using SolutionOrders.API.Features.Items.Messages.DTOs;
using SolutionOrders.API.Models.Data;

namespace SolutionOrders.API.Features.Items.Providers
{
    public class ItemProvider : IItemProvider
    {
        private readonly ApplicationDbContext _context;

        public ItemProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync(CancellationToken cancellationToken = default)
        {
            var items = await _context.Items
                .AsNoTracking()
                .Include(i => i.Category)
                .Include(i => i.UnitOfMeasurement)
                .Where(i => i.IsActive)
                .OrderBy(i => i.Name)
                .ToListAsync(cancellationToken);

            return items.Adapt<IEnumerable<ItemDto>>();
        }

        public async Task<ItemDto?> GetItemByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _context.Items
                .AsNoTracking()
                .Include(i => i.Category)
                .Include(i => i.UnitOfMeasurement)
                .FirstOrDefaultAsync(i => i.IdItem == id && i.IsActive, cancellationToken);

            return item?.Adapt<ItemDto>();
        }
    }
}
