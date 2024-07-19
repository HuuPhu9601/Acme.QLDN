using Acme.QLDN.SqlServerDB;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications.Sql_Managers
{
    [Collection(QLDNTestConsts.CollectionDefinitionName)]
    public class EfCoreSQLMangerAppService_Tests : ManagerSQLAppService_Tests<QLDNEntityFrameworkCoreTestModule>
    {
    }
}
