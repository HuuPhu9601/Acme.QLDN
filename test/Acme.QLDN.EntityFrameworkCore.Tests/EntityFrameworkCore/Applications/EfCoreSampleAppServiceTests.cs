using Acme.QLDN.Samples;
using Xunit;

namespace Acme.QLDN.EntityFrameworkCore.Applications;

[Collection(QLDNTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QLDNEntityFrameworkCoreTestModule>
{

}
