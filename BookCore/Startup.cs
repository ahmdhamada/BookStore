using BookCore.Models;
using BookCore.Models.Repostories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
namespace BookCore
{
    public class Startup
    {
        private readonly IConfiguration configuration;


        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting=false);
            services.AddSingleton<IBookstoreRepostory<Auther>, AuthorRepo>();
            services.AddSingleton<IBookstoreRepostory<Book>, BookRepostory>();
            services.AddDbContext<BookstoreDbContext>(options =>
            {
               options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


               
        
            }

            app.UseStaticFiles();
           app.UseMvcWithDefaultRoute();

           
        }
    }
}
