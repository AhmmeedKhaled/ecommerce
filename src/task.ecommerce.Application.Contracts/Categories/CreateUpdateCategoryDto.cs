using System;
using System.Collections.Generic;
using System.Text;

namespace task.ecommerce.Categories;

public class CreateUpdateCategoryDto
{
    public string ArabicName { get; set; }

    public string EnglishName { get; set; }

    public Guid? ParentCategoryId { get; set; }
}
