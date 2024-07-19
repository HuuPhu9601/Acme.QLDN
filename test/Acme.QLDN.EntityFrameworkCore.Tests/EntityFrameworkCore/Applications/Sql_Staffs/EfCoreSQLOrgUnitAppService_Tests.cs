using Acme.QLDN.SqlServerDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.Sql_Staffs
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreSQLOrgUnitAppService_Tests : StaffSQLAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
