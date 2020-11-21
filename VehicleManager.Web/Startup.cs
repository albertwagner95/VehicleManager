using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleManager.Infrastructure;
using FluentValidation.AspNetCore;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infrastructure.Repositories;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;
using VehicleManager.Application.DependencyInjection;
using VehicleManager.Infrastructure.DependencyInjection;
using FluentValidation;
using VehicleManager.Application.ViewModels.Vehicle;
using static VehicleManager.Application.ViewModels.Vehicle.NewVehicleVm;
using VehicleManager.Domain.Model;
using VehicleManager.Application.ViewModels.AddressVm;
using static VehicleManager.Application.ViewModels.AddressVm.NewAddressVm;

namespace VehicleManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();

             
            services.AddApplication();
            services.AddInfrastructure();
 
            services.AddControllersWithViews().AddFluentValidation().AddFluentValidation(fv => fv.RunDefaultMvcValidationAfterFluentValidationExecutes = true);
            services.AddRazorPages();

            services.AddTransient<IValidator<NewVehicleVm>, NewVehicleValidation>();
            services.AddTransient<IValidator<NewAddressVm>, NewAddressValidation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
