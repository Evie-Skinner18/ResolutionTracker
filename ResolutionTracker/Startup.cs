using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;
using dotenv.net.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResolutionTracker.Data;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services;

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
            // this service will get injected into the relevant controller when it asks for the IResolutionService interface
            services.AddScoped<IResolutionService, ResolutionService>();

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
