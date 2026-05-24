using task.ecommerce.Samples;
using Xunit;

namespace task.ecommerce.EntityFrameworkCore.Domains;

[Collection(ecommerceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ecommerceEntityFrameworkCoreTestModule>
{

}
