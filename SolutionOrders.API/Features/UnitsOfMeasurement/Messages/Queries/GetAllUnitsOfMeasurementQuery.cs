using MediatR;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.DTOs;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Messages.Queries
{
    public class GetAllUnitsOfMeasurementQuery : IRequest<IEnumerable<UnitOfMeasurementDto>>
    {
    }
}