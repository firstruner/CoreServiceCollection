using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using CoreServiceCollection.Localisation.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace CoreServiceCollection.Localisation
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
            services.AddSingleton<IPersonService, PersonService>();

            services.AddLocalization(AddLocalizationOption);

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                                     AddLocalizationOption)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
                o =>
                {
                    var availableCultures = new List<CultureInfo>
                    {
                        new CultureInfo("fr-CA"),
                        new CultureInfo("en-CA")
                    };

                    o.DefaultRequestCulture = new RequestCulture("fr-CA");
                    o.SupportedCultures = availableCultures;
                    o.SupportedUICultures = availableCultures;
                });

            void AddLocalizationOption(LocalizationOptions o)
            {
                o.ResourcesPath = "Resources";
            }

            
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class DisplayNameDetailsProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            var displayAttribute = context.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            if (displayAttribute != null)
            {
                context.DisplayMetadata.DisplayName = () => displayAttribute.DisplayName;
            }
        }
    }
}
