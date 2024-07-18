using Acme.QLDN.Samples;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Domains;

[Collection(QLDNTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QLDNEntityFrameworkCoreTestModule>
{

}
