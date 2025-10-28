using MediatR;
using CategoryService.Domain.Interfaces;

namespace CategoryService.Application.CQRS.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequest<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repo;

    public DeleteCategoryCommandHandler(ICategoryRepository repo) => _repo = repo;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Category {request.Id} not found.");
        await _repo.DeleteAsync(category);
    }
}
