using System;
using System.Collections.Generic;
namespace task.ecommerce.Orders;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;


public class Order : AuditedAggregateRoot<Guid>
{
    public Guid CustomerId { get; private set; }

    public DateTime OrderDate { get; private set; }

    public OrderStatus Status { get; private set; }

    public decimal TotalPrice { get; private set; }

    public ICollection<OrderItem> Items { get; private set; }

    protected Order()
    {
        Items = new List<OrderItem>();
    }

    public Order(
        Guid id,
        Guid customerId)
        : base(id)
    {
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.Pending;

        Items = new List<OrderItem>();
    }

    public void AddItem(
        Guid productId,
        int quantity,
        decimal unitPrice)
    {
        var item = new OrderItem(
            Guid.NewGuid(),
            Id,
            productId,
            quantity,
            unitPrice);

        Items.Add(item);

        RecalculateTotal();
    }

    public void RemoveItem(Guid orderItemId)
    {
        var item = Items.FirstOrDefault(x => x.Id == orderItemId);

        if (item == null)
            return;

        Items.Remove(item);

        RecalculateTotal();
    }

    public void Confirm()
    {
        if (!Items.Any())
        {
            throw new InvalidOperationException(
                "Order must contain at least one item.");
        }

        Status = OrderStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = OrderStatus.Cancelled;
    }

    private void RecalculateTotal()
    {
        TotalPrice = Items.Sum(x => x.GetTotalPrice());
    }
}
