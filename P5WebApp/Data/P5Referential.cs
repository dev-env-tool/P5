using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using P5WebApp.Models.Entities;
using System.Data;

namespace P5WebApp.Data
{
    // Use of a factory to create the Db context
    public class P5ReferentialFactory : IDesignTimeDbContextFactory<P5Referential>
    {
        public P5Referential CreateDbContext(string[] args) 
        {
            var optionsBuilder = new DbContextOptionsBuilder<P5Referential>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=P5Referential;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new P5Referential(optionsBuilder.Options);
        }

    }
    public class P5Referential : DbContext
    {
        private IDbConnection ?DbConnection { get; }

        // Connect with the new database created to store all objects excepted Identity.
        public P5Referential(DbContextOptions<P5Referential> options)
            : base(options)
        {
            
        }

        // Define tables to build.
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Fix> Fixes { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<FinishType> FinishTypes { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<ShortAdd> ShortAdds { get; set; }



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
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");


            // Indicate that Car is the base class to build the cars table.



            modelBuilder.Entity<Car>()
                .ToTable("Cars");


            // Create a table for fixes
            modelBuilder.Entity<Fix>()
                .ToTable("Fixes")
                .HasIndex(f => f.FixId);


            // Indicate the relationship one brand has many models
            modelBuilder.Entity<Brand>()
                .HasMany(m => m.Models)
                .WithOne(b => b.AssociatedBrand)
                .HasForeignKey(b => b.AsociatedBrandId);

            // Create a table for brands 
            modelBuilder.Entity<Brand>()
                .ToTable("Brands")
                .HasIndex(b => b.BrandId);



            // Indicate the relationship many models have one brand
            modelBuilder.Entity<Model>()
                .HasOne(b => b.AssociatedBrand)
                .WithMany(m => m.Models)
                .HasForeignKey(b =>b.AsociatedBrandId);


            // Create a table for models 
            modelBuilder.Entity<Model>()
                .ToTable("Models")
                .HasIndex(m => m.Id);

            // Create a table for finishtypes
            modelBuilder.Entity<FinishType>()
                .ToTable("FinishTypes")
                .HasIndex(f => f.FinishTypeId);

            // Create a table for photos 
            modelBuilder.Entity<Photo>()
                .ToTable("Photos")
                .HasIndex(p => p.Id);

            // Create a table for adds 
            modelBuilder.Entity<ShortAdd>()
                .ToTable("ShortAdds")
                .HasIndex(a => a.Id);
        }

    }
}
