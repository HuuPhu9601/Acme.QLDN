using Microsoft.AspNetCore.Builder;
using Acme.QLDN;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<QLDNWebTestModule>();

public partial class Program
{
}
