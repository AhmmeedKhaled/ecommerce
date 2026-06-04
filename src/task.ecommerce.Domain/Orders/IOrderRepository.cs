using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace task.ecommerce.Orders;

public interface IOrderRepository
    : IRepository<Order, Guid>
{
}
