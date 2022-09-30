using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
        }
    }
}
