using SolutionOrders.API.Features.Items.Messages.DTOs;

namespace SolutionOrders.API.Features.Items.Providers
{
    public interface IItemProvider
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync(CancellationToken cancellationToken = default);
        Task<ItemDto?> GetItemByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
