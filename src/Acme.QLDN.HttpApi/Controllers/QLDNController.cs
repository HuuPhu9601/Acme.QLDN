using Acme.QLDN.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.QLDN.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QLDNController : AbpControllerBase
{
    protected QLDNController()
    {
        LocalizationResource = typeof(QLDNResource);
    }
}
