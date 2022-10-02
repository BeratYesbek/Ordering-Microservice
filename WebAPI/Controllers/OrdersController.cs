using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Queries.GetListByUserId;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Context;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        public OrdersController(ILogger<OrdersController> logger)
        {
            logger.LogInformation("{BookName}{Message}","The lord of the rings","The lord of the rings has been created");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrderCommand)
        {
            var result = await Mediator?.Send(createOrderCommand)!;
            return Ok(result);
        }

        [HttpGet("getByUserId/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute]GetListByUserIdOrderQuery getListByUserIdOrderQuery)
        {
            var results = await Mediator?.Send(getListByUserIdOrderQuery)!;
            return Ok(results);
        }
    }
}
