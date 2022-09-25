using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderRepository : EfEntityRepositoryBase<Order,OrderingDbContext>,IOrderRepository
    {
        public OrderRepository(OrderingDbContext context) : base(context)
        {
        }
    }
}
