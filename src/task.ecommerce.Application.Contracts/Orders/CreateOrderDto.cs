using System;
using System.Collections.Generic;
using System.Text;

namespace task.ecommerce.Orders;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> Items { get; set; }
}
