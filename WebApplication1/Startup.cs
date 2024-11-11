using DataLayer.Entityes;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces.BusinessLayer.interfaces;
using BusinessLayer;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Налаштування контексту бази даних
            services.AddDbContext<_ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Налаштування аутентифікації та Identity
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<_ApplicationContext>()
            .AddDefaultTokenProviders();

            // Налаштування сервісів репозиторіїв
            services.AddTransient<IBaseRepository<Provider>, ProviderRepository>();
            services.AddTransient<IBaseRepository<Doctor>, DoctorRepository>();
            services.AddTransient<IBaseRepository<NameTrade>, NameTradesRepository>();
            services.AddTransient<IBaseExtraRepository<Preparation>, PreparationRepositoty>();
            services.AddScoped<DataManager>();

            // Налаштування кешування та сесій
            services.AddMemoryCache();
            services.AddSession();

            // Додавання контролерів з видами
            services.AddControllersWithViews();

            // Налаштування аутентифікації через cookie
            services.AddAuthentication()
                    .AddCookie();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            // Аутентифікація та авторизація
            app.UseAuthentication();
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
