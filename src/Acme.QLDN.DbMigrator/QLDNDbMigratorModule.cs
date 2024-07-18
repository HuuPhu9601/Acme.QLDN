using Acme.QLDN.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.QLDN.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QLDNEntityFrameworkCoreModule),
    typeof(QLDNApplicationContractsModule)
    )]
public class QLDNDbMigratorModule : AbpModule
{
}
