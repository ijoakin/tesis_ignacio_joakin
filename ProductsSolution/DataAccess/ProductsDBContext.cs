using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext(string connectionString) : base(GetOptions(connectionString))
        {
            try
            {
                //this.Database.EnsureDeleted();
                this.Database.EnsureCreated();
            }
            catch (System.Exception ex)
            {
                
            }
           
            //DbInitializer.DbInitializerFirstUse(this);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalePoint> SalePoints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Search> Searches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<ProductMovement> productMovements { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbQuery<MLModel> MLModelView { get; set; }
        public DbSet<Distance> Distances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Query<MLModel>().ToView("MLModel");

            modelBuilder.Entity<Sale>()
                .HasOne(x => x.User).WithMany(x => x.Sales).OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<Product>()
                .Property(e => e.Description);*/

            //    modelBuilder.Entity<ProductMovement>()
            //    .HasOne<Product>()
            //    .

            //    modelBuilder.Entity<Side>()
            //        .HasRequired(s => s.Stage)
            //        .WithMany()
            //        .WillCascadeOnDelete(false);
            //}
        }
    }
}
