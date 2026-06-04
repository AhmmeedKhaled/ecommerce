using System;
using System.Collections.Generic;
namespace task.ecommerce.Categories;

using global::task.ecommerce.Mappers;

using System.Threading.Tasks;
using task.ecommerce.Mappers;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

public class CategoryAppService : ApplicationService, ICategoryAppService
{
    private readonly IRepository<Category, Guid> _categoryRepository;

    public CategoryAppService(IRepository<Category, Guid> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return category.ToDto();
    }

    public async Task<List<CategoryDto>> GetListAsync()
    {
        var list = await _categoryRepository.GetListAsync();
        return list.ConvertAll(x => x.ToDto());
    }

    [Authorize]
    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var category = new Category(
            GuidGenerator.Create(),
            input.ArabicName,
            input.EnglishName,
            input.ParentCategoryId
        );

        await _categoryRepository.InsertAsync(category);

        return category.ToDto();
    }

    [Authorize]
    public async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        category.SetNames(input.ArabicName, input.EnglishName);
        category.ChangeParent(input.ParentCategoryId);

        await _categoryRepository.UpdateAsync(category);

        return category.ToDto();
    }

    [Authorize]
    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}
