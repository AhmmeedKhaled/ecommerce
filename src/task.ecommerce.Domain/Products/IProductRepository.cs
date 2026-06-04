using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace task.ecommerce.Products;



public interface IProductRepository
    : IRepository<Product, Guid>
{
}
