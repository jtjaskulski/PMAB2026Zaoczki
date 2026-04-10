using MediatR;
using SolutionOrders.API.Features.UnitsOfMeasurement.Messages.DTOs;

namespace SolutionOrders.API.Features.UnitsOfMeasurement.Messages.Queries
{
    public class GetUnitOfMeasurementByIdQuery : IRequest<UnitOfMeasurementDto?>
    {
        public int Id { get; set; }

        public GetUnitOfMeasurementByIdQuery(int id)
        {
            Id = id;
        }
    }
}
