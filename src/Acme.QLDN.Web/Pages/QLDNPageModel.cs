using Acme.QLDN.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.QLDN.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class QLDNPageModel : AbpPageModel
{
    protected QLDNPageModel()
    {
        LocalizationResourceType = typeof(QLDNResource);
    }
}
