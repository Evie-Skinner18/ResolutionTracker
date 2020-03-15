using System;
using System.Text;
using dotenv.net;
using dotenv.net.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResolutionTracker.Data;
using ResolutionTracker.Data.DataAccess;
using ResolutionTracker.Data.DataAccess.Common;
using ResolutionTracker.Services;
using ResolutionTracker.Services.Common;

namespace ResolutionTracker
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
            // set up dotenv to grab the env vars
            DotEnv.Config();
            services.AddEnv(builder => {
                builder
                .AddEnvFile("./.env")
                .AddThrowOnError(false)
                .AddEncoding(Encoding.ASCII);
            });
            var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            services.AddControllersWithViews();

            // set up Postgres
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<ResolutionTrackerContext>(options => options.UseNpgsql(connectionString));

            // add any new services in the service layer here
            services.AddSingleton(Configuration);
            // each service will get injected into the relevant controller when it asks for the interface
            services.AddScoped<IResolutionService, ResolutionService>();
            services.AddScoped<IResolutionReader, ResolutionReader>();
            services.AddScoped<IResolutionWriter, ResolutionWriter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
