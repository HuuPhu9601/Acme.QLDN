using System.Threading.Tasks;

namespace Acme.QLDN.Data;

public interface IQLDNDbSchemaMigrator
{
    Task MigrateAsync();
}
