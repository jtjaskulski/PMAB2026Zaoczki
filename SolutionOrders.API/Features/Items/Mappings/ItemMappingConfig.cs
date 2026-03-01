using Mapster;
using SolutionOrders.API.Features.Items.Messages.DTOs;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Features.Items.Mappings
{
    public class ItemMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Item, ItemDto>()
                .Map(dest => dest.CategoryName, src => src.Category != null ? src.Category.Name : null)
                .Map(dest => dest.UnitName, src => src.UnitOfMeasurement != null ? src.UnitOfMeasurement.Name : null);
        }
    }
}
