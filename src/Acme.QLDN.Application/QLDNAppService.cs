using Acme.QLDN.Localization;
using Volo.Abp.Application.Services;

namespace Acme.QLDN;

/* Inherit your application services from this class.
 */
public abstract class QLDNAppService : ApplicationService
{
    protected QLDNAppService()
    {
        LocalizationResource = typeof(QLDNResource);
    }
}
