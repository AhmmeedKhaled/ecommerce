using System;
using System.Collections.Generic;
using System.Text;

namespace task.ecommerce.Mappers;

using global::task.ecommerce.Categories;
using global::task.ecommerce.Orders;
using global::task.ecommerce.Products;
using System.Linq;

public static class MappingExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            ArabicName = category.ArabicName,
            EnglishName = category.EnglishName,
            ParentCategoryId = category.ParentCategoryId
        };
    }

    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            ArabicName = product.ArabicName,
            EnglishName = product.EnglishName,
            ArabicDescription = product.ArabicDescription,
            EnglishDescription = product.EnglishDescription,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CategoryId = product.CategoryId
        };
    }

    public static OrderItemDto ToDto(this OrderItem item)
    {
        return new OrderItemDto
        {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        };
    }

    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            Items = order.Items
                .Select(x => x.ToDto())
                .ToList()
        };
    }
}
