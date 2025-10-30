using MediatR;
using CategoryService.Domain.Interfaces;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category?>
{
    private readonly ICategoryRepository _repo;

    public GetCategoryByIdQueryHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}
