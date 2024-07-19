using Acme.QLDN.InMemoryDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.Managers
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreMangerAppService_Tests : ManagerAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
