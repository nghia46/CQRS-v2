using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCQRSProject.Commands.Commands.ProductC;
using MyCQRSProject.Queries.Queries.ProductQ;

namespace MyCQRSProject.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}