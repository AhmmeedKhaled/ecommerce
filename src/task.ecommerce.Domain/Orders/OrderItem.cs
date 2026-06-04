using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace task.ecommerce.Orders;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; }

    public Guid ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    protected OrderItem()
    {
    }

    public OrderItem(
        Guid id,
        Guid orderId,
        Guid productId,
        int quantity,
        decimal unitPrice)
        : base(id)
    {
        if (quantity <= 0)
            throw new ArgumentException(nameof(quantity));

        if (unitPrice <= 0)
            throw new ArgumentException(nameof(unitPrice));

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public decimal GetTotalPrice()
    {
        return Quantity * UnitPrice;
    }
}
