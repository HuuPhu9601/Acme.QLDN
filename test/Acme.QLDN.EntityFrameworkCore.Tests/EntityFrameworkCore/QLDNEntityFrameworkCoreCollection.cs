using Xunit;

namespace Acme.QLDN.EntityFrameworkCore;

[CollectionDefinition(QLDNTestConsts.CollectionDefinitionName)]
public class QLDNEntityFrameworkCoreCollection : ICollectionFixture<QLDNEntityFrameworkCoreFixture>
{

}
