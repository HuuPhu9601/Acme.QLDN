using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.QLDN.Web;

[Dependency(ReplaceServices = true)]
public class QLDNBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "QLDN";
}
