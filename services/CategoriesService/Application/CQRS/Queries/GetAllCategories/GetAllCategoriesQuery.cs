using MediatR;
using CategoryService.Domain.Entities;

namespace CategoryService.Application.CQRS.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<IEnumerable<Category>>;
