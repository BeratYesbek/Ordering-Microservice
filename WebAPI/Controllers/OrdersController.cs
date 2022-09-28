using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Queries.GetListByUserId;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {

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
