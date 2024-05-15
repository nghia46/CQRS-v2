using MyCQRSProject.Domain.Entities;
using MediatR;

namespace MyCQRSProject.Commands.Commands.ProductC;

public record AddProductCommand(Product Product) : IRequest<bool>;
