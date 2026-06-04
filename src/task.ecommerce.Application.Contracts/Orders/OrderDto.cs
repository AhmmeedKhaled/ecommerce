using System;
using System.Collections.Generic;
using System.Text;


namespace task.ecommerce.Orders;

public class OrderDto
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public List<OrderItemDto> Items { get; set; }
}
