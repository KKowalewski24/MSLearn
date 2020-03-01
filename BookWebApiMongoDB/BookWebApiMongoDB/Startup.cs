using BookWebApiMongoDB.Services;
using BookWebApiMongoDB.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookWebApiMongoDB
{
    public class Startup
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        public IConfiguration Configuration { get; }

        /*------------------------ METHODS REGION ------------------------*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>((it) =>
                it.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<BookService>();

            services.AddControllers().AddNewtonsoftJson((it) => it.UseMemberCasing());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}