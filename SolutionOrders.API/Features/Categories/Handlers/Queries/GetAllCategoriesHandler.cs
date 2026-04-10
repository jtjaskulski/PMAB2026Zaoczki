using Mapster;
using MediatR;
using SolutionOrders.API.Features.Categories.Messages.DTOs;
using SolutionOrders.API.Features.Categories.Messages.Queries;
using SolutionOrders.API.Features.Categories.Providers;

namespace SolutionOrders.API.Features.Categories.Handlers.Queries
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryProvider _CategoryProvider;

        public GetAllCategoriesHandler(ICategoryProvider CategoryProvider)
        {
            _CategoryProvider = CategoryProvider;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (await _CategoryProvider.GetAllCategoriesAsync(true ,cancellationToken))
                .Adapt<IEnumerable<CategoryDto>>();
        }
    }
}