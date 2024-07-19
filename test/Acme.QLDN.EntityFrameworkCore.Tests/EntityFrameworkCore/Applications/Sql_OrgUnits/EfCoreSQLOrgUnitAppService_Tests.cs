using Acme.QLDN.SqlServerDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.Sql_OrgUnits
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreSQLOrgUnitAppService_Tests : OrgUnitSQLAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
