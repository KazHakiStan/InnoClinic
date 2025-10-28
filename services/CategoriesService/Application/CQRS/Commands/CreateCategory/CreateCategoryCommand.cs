using MediatR;

namespace CategoryService.Application.CQRS.Commands.CreateCategory;

public record CreateCategoryCommand(
    string CategoryName,
    DateTime TimeSlotSize
    ) : IRequest<Guid>;
