using task.ecommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace task.ecommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ecommerceController : AbpControllerBase
{
    protected ecommerceController()
    {
        LocalizationResource = typeof(ecommerceResource);
    }
}
