using Mapster;
using MediatR;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.DTOs;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.Queries;
using SolutionOrders.API.Features.UnitsOfMeasurement.Providers;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Handlers.Queries
{
    public class GetAllUnitsOfMeasureHandler(IUnitOfMeasurementProvider unitOfMeasureProvider)
        : IRequestHandler<GetAllUnitsOfMeasurementQuery, IEnumerable<UnitOfMeasurementDto>>
    {
        public async Task<IEnumerable<UnitOfMeasurementDto>> Handle(GetAllUnitsOfMeasurementQuery request, CancellationToken cancellationToken)
        {
            return (await unitOfMeasureProvider.GetAllUnitsOfMeasurementAsync(true ,cancellationToken))
                .Adapt<IEnumerable<UnitOfMeasurementDto>>();
        }
    }
}