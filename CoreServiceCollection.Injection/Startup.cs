using AutoMapper;
using CoreServiceCollection.Core.Services;
using CoreServiceCollection.Injection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CoreServiceCollection.Injection
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
            services.AddAutoMapper();
            services.AddMvc();

            services.AddSingleton<IPersonService, PersonService>();
            services.AddScoped<IIdentifierServiceScoped, IdentifierService>();
            services.AddTransient<IIdentifierServiceTransient, IdentifierService>();

            services.Configure<MyOptions>(Configuration);

            #region à voir plus tard
            services.AddTransient<ILoggingService, LoggingService>(provider =>
            {
                var config = provider.GetService<IOptions<MyOptions>>();
                return new LoggingService(config.Value.LoggerFileLocation);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
