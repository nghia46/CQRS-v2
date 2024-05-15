using MediatR;
using MyCQRSProject.Domain.Entities;

namespace MyCQRSProject.Queries.Queries.ProductQ;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
