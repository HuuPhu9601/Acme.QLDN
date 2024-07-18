using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.QLDN.Data;

/* This is used if database provider does't define
 * IQLDNDbSchemaMigrator implementation.
 */
public class NullQLDNDbSchemaMigrator : IQLDNDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
