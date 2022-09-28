using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Queries.GetListByUserId
{
    public class GetListByUserIdOrderQueryHandler : IRequestHandler<GetListByUserIdOrderQuery, List<OrderListDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListByUserIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderListDto>> Handle(GetListByUserIdOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetAllAsync();
            var orderListDto = _mapper.Map<List<OrderListDto>>(result);
            return orderListDto;
        }
    }
}
