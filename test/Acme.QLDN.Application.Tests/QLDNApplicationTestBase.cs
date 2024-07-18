using Volo.Abp.Modularity;

namespace Acme.QLDN;

public abstract class QLDNApplicationTestBase<TStartupModule> : QLDNTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
