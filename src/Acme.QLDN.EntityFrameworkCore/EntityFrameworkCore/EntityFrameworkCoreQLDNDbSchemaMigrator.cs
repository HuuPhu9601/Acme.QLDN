using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.QLDN.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.QLDN.EntityFrameworkCore;

public class EntityFrameworkCoreQLDNDbSchemaMigrator
    : IQLDNDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreQLDNDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the QLDNDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<QLDNDbContext>()
            .Database
            .MigrateAsync();
    }
}
