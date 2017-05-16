using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Speech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Speech
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddDbContext<SpeechDbContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SpeechDbContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app)
        {
            var context1 = app.ApplicationServices.GetService<SpeechDbContext>();
            AddTestData(context1);

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public static void AddTestData(SpeechDbContext context1)
        {
            var content1 = new Models.Review
            {
                Name = "Rachel",
                Description = "This was the best thing I could have ever done for my son Liam. Asides from correcting his speech impediment, his confidence shot through the roof and he always had such a blast."
            };

            context1.Reviews.Add(content1);

            var content2 = new Models.Review
            {
                Name = "Kristen",
                Description = "I cannot ut into words how thankful I am for Dayna and Speech Solutions. As my family and I live in a mountainous area of the PNW we do not have easy access to many services like this, but the online option was fantastic and greatly improved my son's life."
            };

            context1.Reviews.Add(content2);

            var content3 = new Models.Review
            {
                Name = "Sean",
                Description = "This is great. My daughter made so much progress and I definitely recommend it."
            };

            context1.Reviews.Add(content3);

            context1.SaveChanges();
        }
    }
}
