using System;
using System.Collections.Generic;
using System.Text;
using task.ecommerce.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace task.ecommerce.Products;


public class Product : AuditedAggregateRoot<Guid>
{
    public string ArabicName { get; private set; }

    public string EnglishName { get; private set; }

    public string ArabicDescription { get; private set; }

    public string EnglishDescription { get; private set; }

    public decimal Price { get; private set; }

    public int StockQuantity { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public Guid CustomerId { get; private set; }

    protected Product()
    {
    }

    public Product(
        Guid id,
        string arabicName,
        string englishName,
        string arabicDescription,
        string englishDescription,
        decimal price,
        int stockQuantity,
        Guid categoryId)
        : base(id)
    {
        SetNames(arabicName, englishName);

        SetDescriptions(
            arabicDescription,
            englishDescription);

        ChangePrice(price);

        SetStock(stockQuantity);

        CategoryId = categoryId;
    }

    public void SetNames(
        string arabicName,
        string englishName)
    {
        if (string.IsNullOrWhiteSpace(arabicName))
            throw new ArgumentException(nameof(arabicName));

        if (string.IsNullOrWhiteSpace(englishName))
            throw new ArgumentException(nameof(englishName));

        ArabicName = arabicName.Trim();
        EnglishName = englishName.Trim();
    }

    public void SetDescriptions(
        string arabicDescription,
        string englishDescription)
    {
        ArabicDescription = arabicDescription?.Trim();
        EnglishDescription = englishDescription?.Trim();
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Price = price;
    }

    public void SetStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Stock cannot be negative.");

        StockQuantity = quantity;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException(nameof(quantity));

        StockQuantity += quantity;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException(nameof(quantity));

        if (StockQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        StockQuantity -= quantity;
    }

    public void ChangeCategory(Guid categoryId)
    {
        CategoryId = categoryId;
    }
}