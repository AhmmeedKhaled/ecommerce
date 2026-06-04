using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace task.ecommerce.Categories;

public class Category : AuditedAggregateRoot<Guid>
{
    public string ArabicName { get; private set; }

    public string EnglishName { get; private set; }

    public Guid? ParentCategoryId { get; private set; }
    public Category ParentCategory { get; private set; }
    public ICollection<Category> Children { get; private set; }

    protected Category()
    {
        Children = new List<Category>();
    }

    public Category(
        Guid id,
        string arabicName,
        string englishName,
        Guid? parentCategoryId = null)
        : base(id)
    {
        SetNames(arabicName, englishName);

        ParentCategoryId = parentCategoryId;
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

    public void ChangeParent(Guid? parentCategoryId)
    {
        ParentCategoryId = parentCategoryId;
    }
}