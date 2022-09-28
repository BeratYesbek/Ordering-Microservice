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
 
        [HttpGet("getByUserId/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute]GetListByUserIdOrderQuery getListByUserIdOrderQuery)
        {
            var results = await Mediator?.Send(getListByUserIdOrderQuery)!;
            return Ok(results);
        }
    }
}
