using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;

namespace P5WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ShortAdd services to the container.
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


            var app = builder.Build();

            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.Run();
        }
    }
}
