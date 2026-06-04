using System;
using System.Collections.Generic;
using System.Text;

namespace task.ecommerce.Orders;

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}
