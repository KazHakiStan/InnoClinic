using MediatR;

namespace CategoryService.Application.CQRS.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequest;
