using Mapster;
using MediatR;
using SolutionOrders.API.Features.Categories.Messages.DTOs;
using SolutionOrders.API.Features.Categories.Messages.Queries;
using SolutionOrders.API.Features.Categories.Providers;

namespace SolutionOrders.API.Features.Categories.Handlers.Queries
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly ICategoryProvider _CategoryProvider;

        public GetCategoryByIdHandler(ICategoryProvider CategoryProvider)
        {
            _CategoryProvider = CategoryProvider;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _CategoryProvider.GetCategoryByIdAsync(request.Id ,true, cancellationToken))?
                .Adapt<CategoryDto>();
        }
    }
}