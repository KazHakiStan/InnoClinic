using MediatR;

namespace CategoryService.Application.CQRS.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string CategoryName,
    DateTime TimeSlotSize
    ) : IRequest;
