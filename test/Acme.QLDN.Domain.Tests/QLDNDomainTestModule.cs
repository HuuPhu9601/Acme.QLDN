using Volo.Abp.Modularity;

namespace Acme.QLDN;

[DependsOn(
    typeof(QLDNDomainModule),
    typeof(QLDNTestBaseModule)
)]
public class QLDNDomainTestModule : AbpModule
{

}
