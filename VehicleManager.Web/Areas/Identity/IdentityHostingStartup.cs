using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(VehicleManager.Web.Areas.Identity.IdentityHostingStartup))]
namespace VehicleManager.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}