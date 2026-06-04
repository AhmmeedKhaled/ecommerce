using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace task.ecommerce.Orders;

public interface IOrderAppService
    : IApplicationService
{
    Task<OrderDto> CreateAsync(List<CreateOrderItemDto> input);

    Task<List<OrderDto>> GetMyOrdersAsync();

    Task<List<OrderDto>> GetAllAsync();
}
