using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<List<Order>, List<OrderListDto>>().ReverseMap();
        }
    }
}
