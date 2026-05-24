using task.ecommerce.Localization;
using Volo.Abp.Application.Services;

namespace task.ecommerce;

/* Inherit your application services from this class.
 */
public abstract class ecommerceAppService : ApplicationService
{
    protected ecommerceAppService()
    {
        LocalizationResource = typeof(ecommerceResource);
    }
}
