using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Spotify.Client.Application.Extensions;
using Spotify.Client.Domain.Extensions;
using Spotify.Client.Infrastructure.Extensions;
using Spotify.Client.Ui.Extensions;

namespace Spotify.Client.Ui
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Called for ASPNETCORE_ENVIRONMENT=Development
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
            services.AddInfrastructure();
            services.AddDomainServices();
            services.AddUseCases();
            services.AddSpotifyAuthentication();
            services.AddSpotifyClientPresenters();
            services.AddSpotifyClientMediatorPipelines();
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion

        #region Called for ASPNETCORE_ENVIRONMENT=Production
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
            services.AddInfrastructure();
            services.AddDomainServices();
            services.AddUseCases();
            services.AddSpotifyAuthentication();
            services.AddSpotifyClientPresenters();
            services.AddSpotifyClientMediatorPipelines();
        }

        public void ConfigureProduction(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
