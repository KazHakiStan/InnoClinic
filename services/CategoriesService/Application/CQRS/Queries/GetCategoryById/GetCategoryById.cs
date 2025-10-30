using MediatR;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<Category?>;
