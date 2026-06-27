using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using P3AddNewFunctionalityDotNetCore.Data;
using P5WebApp.Data;
using P5WebApp.Models;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using System.Runtime.CompilerServices;


namespace P5WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();

            // Add services to the container.
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();

            builder.Services.AddScoped<ICarModelService, CarModelService>();
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();

            builder.Services.AddScoped<IFinishTypeService, FinishTypeService>();
            builder.Services.AddScoped<IFinishTypeRepository, FinishTypeRepository>();

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();

            builder.Services.AddScoped<IFixService, FixService>();
            builder.Services.AddScoped<IFixRepository, FixRepository>();

            builder.Services.AddScoped<IShortAddService, ShortAddService>();
            builder.Services.AddScoped<IShortAddRepository, ShortAddRepository>();

            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

            // Add DB contexts to the app.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var connectionStringP5Referential = builder.Configuration.GetConnectionString("P5Referential") ?? throw new InvalidOperationException("Connection string 'P5Referential' not found.");
            builder.Services.AddDbContext<P5Referential>(options =>
                options.UseSqlServer(connectionStringP5Referential));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();




            var supportedCultures = new[] { "fr-FR", "fr" };

            builder.Services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
            });

            var app = builder.Build();

            app.UseStaticFiles();


            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures.ToArray())
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                //using (var scope = app.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;
                //    var contextToUse = services.GetRequiredService<AppIdentityDbContext>();
                //}

                //app.SeedDatabase();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // <summary> add for scaffolding auth pages 
            app.UseAuthentication();
            // <\summary>
            app.UseAuthorization();

            //app.MapStaticAssets();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();
            //app.MapRazorPages()
            //   .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            var optionsBuilder = new DbContextOptionsBuilder<P5Referential>();
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=P5Referential;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=P5Referential;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            using var context = new P5Referential(optionsBuilder.Options);
            bool canConnect = context.Database.CanConnect();
            Console.WriteLine(canConnect ? "SQL Connection OK" : "SQL connection failed");

            await IdentitySeedData.EnsurePopulated(app);


            app.UseAntiforgery();


            app.Run();
        }
    }
}
