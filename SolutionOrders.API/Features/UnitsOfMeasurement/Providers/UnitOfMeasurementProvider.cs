using Microsoft.EntityFrameworkCore;
using SolutionOrders.API.Models;
using SolutionOrders.API.Models.Data;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Providers
{
    public class UnitOfMeasurementProvider(ApplicationDbContext context) : IUnitOfMeasurementProvider
    {
        public async Task<IEnumerable<UnitOfMeasurement>> GetAllUnitsOfMeasurementAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = context.UnitOfMeasurements
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .OrderBy(item => item.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<UnitOfMeasurement> GetUnitOfMeasurementByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = context.UnitOfMeasurements
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var item = await query
                .FirstOrDefaultAsync(i => i.IdUnitOfMeasurement == id && i.IsActive, cancellationToken);

            return item ?? throw new KeyNotFoundException($"Kategoria o ID {id} nie istnieje");
        }
    }
}