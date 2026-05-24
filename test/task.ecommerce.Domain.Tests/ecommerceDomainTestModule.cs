using Volo.Abp.Modularity;

namespace task.ecommerce;

[DependsOn(
    typeof(ecommerceDomainModule),
    typeof(ecommerceTestBaseModule)
)]
public class ecommerceDomainTestModule : AbpModule
{

}
