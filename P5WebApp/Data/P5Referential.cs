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

        // Define tables to create.
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Fix> Fixes { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<FinishType> FinishTypes { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Add> Adds { get; set; }

    }
}
