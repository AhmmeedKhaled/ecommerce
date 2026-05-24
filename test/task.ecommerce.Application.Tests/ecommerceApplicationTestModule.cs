using Volo.Abp.Modularity;

namespace task.ecommerce;

[DependsOn(
    typeof(ecommerceApplicationModule),
    typeof(ecommerceDomainTestModule)
)]
public class ecommerceApplicationTestModule : AbpModule
{

}
