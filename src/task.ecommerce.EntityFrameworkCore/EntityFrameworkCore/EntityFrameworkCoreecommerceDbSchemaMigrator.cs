using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task.ecommerce.Data;
using Volo.Abp.DependencyInjection;

namespace task.ecommerce.EntityFrameworkCore;

public class EntityFrameworkCoreecommerceDbSchemaMigrator
    : IecommerceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreecommerceDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ecommerceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ecommerceDbContext>()
            .Database
            .MigrateAsync();
    }
}
