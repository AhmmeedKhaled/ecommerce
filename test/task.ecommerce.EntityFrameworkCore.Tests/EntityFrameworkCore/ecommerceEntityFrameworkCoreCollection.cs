using Xunit;

namespace task.ecommerce.EntityFrameworkCore;

[CollectionDefinition(ecommerceTestConsts.CollectionDefinitionName)]
public class ecommerceEntityFrameworkCoreCollection : ICollectionFixture<ecommerceEntityFrameworkCoreFixture>
{

}
