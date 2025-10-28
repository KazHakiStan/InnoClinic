using MediatR;
using AutoMapper;
using CategoryService.Domain.Interfaces;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _repo;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _repo.UpdateAsync(category);
        return Unit.Value;
    }
}
