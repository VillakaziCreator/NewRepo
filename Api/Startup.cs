using DataAccessService.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesCore.Student;
using ServicesCorev1._0.CourseService;
using ServicesCorev1._0.StudentService;

namespace Api
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
            services.AddControllers();
            IServiceCollection serviceCollections = services.AddDbContext<DataAccessContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DBConnection1"),
                x => x.MigrationsAssembly("DataAccessService")));

            services.AddScoped<IStudentInterface, StudentImplementation>();
            services.AddScoped<ICourseInterface, CourseImplementation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Student}/{action=GetStudentModel}");
            //    endpoints.MapRazorPages();
            //});
        }
    }
}
