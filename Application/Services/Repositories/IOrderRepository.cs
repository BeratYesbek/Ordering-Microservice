using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface IOrderRepository : IEntityRepository<Order>,IAsyncEntityRepository<Order>
    {
    }
}
