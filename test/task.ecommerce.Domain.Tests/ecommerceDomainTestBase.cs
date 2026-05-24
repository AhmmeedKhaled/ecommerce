using Volo.Abp.Modularity;

namespace task.ecommerce;

/* Inherit from this class for your domain layer tests. */
public abstract class ecommerceDomainTestBase<TStartupModule> : ecommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
