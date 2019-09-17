using CoreMvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CoreMvc.Areas.Identity.IdentityHostingStartup))]
namespace CoreMvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AppDbConetxt>();
            });
        }
    }
}