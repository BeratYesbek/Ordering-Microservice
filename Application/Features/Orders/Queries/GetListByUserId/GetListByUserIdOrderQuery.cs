using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Dtos;
using MediatR;

namespace Application.Features.Orders.Queries.GetListByUserId
{
    public class GetListByUserIdOrderQuery : IRequest<List<OrderListDto>>
    {
        public int UserId { get; set; }

        public GetListByUserIdOrderQuery(int userId)
        {
            UserId = userId;
        }
    }
}
