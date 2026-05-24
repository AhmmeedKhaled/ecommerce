using Volo.Abp.Modularity;

namespace task.ecommerce;

public abstract class ecommerceApplicationTestBase<TStartupModule> : ecommerceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
