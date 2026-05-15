using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using System.Data;

namespace P5WebApp.Data
{
    public class P5Referential : DbContext
    {
        private IDbConnection ?DbConnection { get; }

        // Connect with the new database created to store all objects excepted Identity.
        public P5Referential(DbContextOptions<P5Referential> options, IConfiguration config)
            : base(options)
        {
            DbConnection = new SqlConnection(config.GetConnectionString("P5Referential"));
        }

        // Define tables to build.
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Fix> Fixes { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<FinishType> FinishTypes { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Add> Adds { get; set; }



        // If optionsBuilder is not setup, then configure it.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection?.ConnectionString, providerOptions => providerOptions.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(c => c.VehicleId)
                .HasDatabaseName("CarDb");
            });

            modelBuilder.Entity<Fix>(entity =>
            {
                entity.HasIndex(f => f.FixId)
                .HasDatabaseName("FixDb");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(b => b.BrandId)
                .HasDatabaseName("BrandDb");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasIndex(m => m.VehicleModelId)
                .HasDatabaseName("ModelDb");
            });

            modelBuilder.Entity<FinishType>(entity =>
            {
                entity.HasIndex(f => f.FinishTypeId)
                .HasDatabaseName("FinishTypeDb");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasIndex(p => p.PhotoId)
                .HasDatabaseName("PhotoDb");
            });

            modelBuilder.Entity<Add>(entity =>
            {
                entity.HasIndex(p => p.Id)
                .HasDatabaseName("AddDb");
            });
        }







    }
}
