using MediatR;
using AutoMapper;
using CategoryService.Domain.Interfaces;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _repo;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        category.Id = Guid.NewGuid();
        await _repo.AddAsync(category);
        return category.Id;
    }
}
