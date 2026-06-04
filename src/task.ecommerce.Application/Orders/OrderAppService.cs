using System;
using System.Collections.Generic;
using global::task.ecommerce.Mappers;
using global::task.ecommerce.Products;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace task.ecommerce.Orders;


public class OrderAppService : ApplicationService
{
    private readonly IRepository<Order, Guid> _orderRepository;
    private readonly IRepository<Product, Guid> _productRepository;

    public OrderAppService(
        IRepository<Order, Guid> orderRepository,
        IRepository<Product, Guid> productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    [UnitOfWork]
    public async Task<OrderDto> CreateAsync(List<CreateOrderItemDto> items)
    {
        var order = new Order(
            GuidGenerator.Create(),
            CurrentUser.GetId());

        foreach (var item in items)
        {
            var product = await _productRepository.GetAsync(item.ProductId);

            if (product.StockQuantity < item.Quantity)
                throw new Exception("Not enough stock");

            product.ReduceStock(item.Quantity);

            order.AddItem(
                product.Id,
                item.Quantity,
                product.Price);
        }

        order.Confirm();

        await _orderRepository.InsertAsync(order);

        return order.ToDto();
    }

    public async Task<List<OrderDto>> GetMyOrdersAsync()
    {
        var userId = CurrentUser.GetId();

        var list = await _orderRepository.GetListAsync(
            x => x.CustomerId == userId);

        return list.Select(x => x.ToDto()).ToList();
    }

    [Authorize]
    public async Task<List<OrderDto>> GetAllAsync()
    {
        var list = await _orderRepository.GetListAsync();
        return list.Select(x => x.ToDto()).ToList();
    }
}
