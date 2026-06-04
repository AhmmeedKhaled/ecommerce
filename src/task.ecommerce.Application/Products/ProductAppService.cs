using System;
using System.Collections.Generic;
using System.Text;
using global::task.ecommerce.Categories;
using global::task.ecommerce.Mappers;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Repositories;

namespace task.ecommerce.Products;



public class ProductAppService : ApplicationService
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public ProductAppService(
        IRepository<Product, Guid> productRepository,
        IRepository<Category, Guid> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ProductDto>> GetListAsync()
    {
        var list = await _productRepository.GetListAsync();
        return list.ConvertAll(x => x.ToDto());
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);
        return product.ToDto();
    }

    [Authorize]
    public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        var category = await _categoryRepository.FindAsync(input.CategoryId);

        if (category == null)
            throw new Exception("Category not found");

        var product = new Product(
            GuidGenerator.Create(),
            input.ArabicName,
            input.EnglishName,
            input.ArabicDescription,
            input.EnglishDescription,
            input.Price,
            input.StockQuantity,
            input.CategoryId
        );

        await _productRepository.InsertAsync(product);

        return product.ToDto();
    }

    [Authorize]
    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}
