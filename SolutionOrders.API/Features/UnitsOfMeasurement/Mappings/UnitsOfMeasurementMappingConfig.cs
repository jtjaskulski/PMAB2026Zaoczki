using Mapster;
using SolutionOrders.API.Features.Categories.Messages.DTOs;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.DTOs;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Mappings
{
    public class UnitsOfMeasurementMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UnitOfMeasurement, UnitOfMeasurementDto>();
        }
    }
}