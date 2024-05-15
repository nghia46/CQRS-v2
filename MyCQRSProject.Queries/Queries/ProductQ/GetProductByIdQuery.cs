using MediatR;
using MyCQRSProject.Domain.Entities;

namespace MyCQRSProject.Queries.Queries.ProductQ;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
