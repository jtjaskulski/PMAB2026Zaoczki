using Mapster;
using MediatR;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.DTOs;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.Queries;
using SolutionOrders.API.Features.UnitsOfMeasurement.Providers;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Handlers.Queries
{
    public class GetUnitOfMeasurementByIdHandler : IRequestHandler<GetUnitOfMeasurementByIdQuery, UnitOfMeasurementDto?>
    {
        private readonly IUnitOfMeasurementProvider _UnitOfMeasurementProvider;

        public GetUnitOfMeasurementByIdHandler(IUnitOfMeasurementProvider UnitOfMeasurementProvider)
        {
            _UnitOfMeasurementProvider = UnitOfMeasurementProvider;
        }

        public async Task<UnitOfMeasurementDto?> Handle(GetUnitOfMeasurementByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _UnitOfMeasurementProvider.GetUnitOfMeasurementByIdAsync(request.Id ,true, cancellationToken))?
                .Adapt<UnitOfMeasurementDto>();
        }
    }
}