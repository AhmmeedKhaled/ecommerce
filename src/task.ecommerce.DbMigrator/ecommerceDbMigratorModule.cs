using task.ecommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace task.ecommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ecommerceEntityFrameworkCoreModule),
    typeof(ecommerceApplicationContractsModule)
)]
public class ecommerceDbMigratorModule : AbpModule
{
}
