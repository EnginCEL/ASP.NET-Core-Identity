using System;
using Asp.Net_Core_Identity.Areas.Identity.Data;
using Asp.Net_Core_Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Asp.Net_Core_Identity.Areas.Identity.IdentityHostingStartup))]
namespace Asp.Net_Core_Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AspNet_Core_IdentityDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AspNet_Core_IdentityDBContextConnection")));

                services.AddDefaultIdentity<Application_User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<AspNet_Core_IdentityDBContext>();
            });
        }
    }
}