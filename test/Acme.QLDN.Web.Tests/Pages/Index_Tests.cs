using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.QLDN.Pages;

public class Index_Tests : QLDNWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
