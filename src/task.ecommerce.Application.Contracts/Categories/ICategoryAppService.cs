using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace task.ecommerce.Categories;

public interface ICategoryAppService : IApplicationService
{
    Task<CategoryDto> GetAsync(Guid id);

    Task<List<CategoryDto>> GetListAsync();

    Task<CategoryDto> CreateAsync(
        CreateUpdateCategoryDto input);

    Task<CategoryDto> UpdateAsync(
        Guid id,
        CreateUpdateCategoryDto input);

    Task DeleteAsync(Guid id);
}
