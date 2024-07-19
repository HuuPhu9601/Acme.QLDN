using Acme.QLDN.InMemoryDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.Staffs
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreStaffAppService_Tests : StaffAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
