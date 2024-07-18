using Volo.Abp.Modularity;

namespace Acme.QLDN;

/* Inherit from this class for your domain layer tests. */
public abstract class QLDNDomainTestBase<TStartupModule> : QLDNTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
