using System;
using System.Collections.Generic;
using System.Text;

namespace task.ecommerce.Products;

public class ProductDto
{
    public Guid Id { get; set; }

    public string ArabicName { get; set; }

    public string EnglishName { get; set; }

    public string ArabicDescription { get; set; }

    public string EnglishDescription { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public Guid CategoryId { get; set; }
}
