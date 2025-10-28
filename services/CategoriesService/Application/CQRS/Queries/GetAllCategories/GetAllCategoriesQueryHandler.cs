using MediatR;
using CategoryService.Domain.Interfaces;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _repo;

    public GetAllCategoriesQueryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Category>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
