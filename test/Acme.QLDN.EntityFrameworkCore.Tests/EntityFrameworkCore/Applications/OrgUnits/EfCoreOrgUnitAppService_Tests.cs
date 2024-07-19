using Acme.QLDN.InMemoryDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.OrgUnits
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreOrgUnitAppService_Tests : OrgUnitAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
