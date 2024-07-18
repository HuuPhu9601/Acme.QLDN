using Volo.Abp.Modularity;

namespace Acme.QLDN;

[DependsOn(
    typeof(QLDNApplicationModule),
    typeof(QLDNDomainTestModule)
)]
public class QLDNApplicationTestModule : AbpModule
{

}
