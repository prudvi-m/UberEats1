using Microsoft.EntityFrameworkCore;

namespace UberEats.Models
{
    public class UberContext : DbContext
    {
        public UberContext(DbContextOptions<UberContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Restaurant" },
                new Category { CategoryID = 2, Name = "Grocery" },
                new Category { CategoryID = 3, Name = "Alcohol" },
                new Category {CategoryID=4, Name="Convienience"},
                new Category {CategoryID=5, Name="Flower shop"},
                new Category {CategoryID=6,Name="Pet Store"},
                new Category {CategoryID=7,Name="retail"}
            );

            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    PartnerID = 1,
                    CategoryID = 1,
                    BusinessName = "intial",
                    BusinessAddress = "Chicago, 3001",
                    BusinessEmail = "intial@gmail.com",
                    BusinessPhone = "123456"
                }
            );
        }
    }
}