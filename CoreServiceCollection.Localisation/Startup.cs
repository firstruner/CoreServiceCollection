using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using CoreServiceCollection.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
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
            //services.AddResponseCompression();
            //services.AddAntiforgery();
            //services.AddAuthentication();
            //services.AddMemoryCache();
            //services.AddApplicationInsightsTelemetry();
            //services.AddAuthenticationCore();
            //services.AddAuthorization();
            //services.AddAuthorizationPolicyEvaluator();
            //services.AddCors();
            //services.AddDataProtection();
            //services.AddDirectoryBrowser();
            //services.AddDistributedMemoryCache();
            //services.AddDistributedRedisCache();
            //services.AddDistributedSqlServerCache();
            //services.AddIdentity<>();
            //services.AddIdentityCore<>();
            //services.AddLogging();
            //services.AddMiddlewareAnalysis();
            //services.AddNodeServices();
            //services.AddOptions();
            //services.AddRemoteScheme<>();
            //services.AddResponseCaching();
            //services.AddRouting();
            //services.AddSpaPrerenderer();
            //services.AddWebEncoders();
            //services.AddSession();

            services.AddAutoMapper();
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
                o.ResourcesPath = string.Empty;
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
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{area=Home}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
