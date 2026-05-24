using task.ecommerce.Samples;
using Xunit;

namespace task.ecommerce.EntityFrameworkCore.Applications;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ecommerceEntityFrameworkCoreTestModule>
{

}
