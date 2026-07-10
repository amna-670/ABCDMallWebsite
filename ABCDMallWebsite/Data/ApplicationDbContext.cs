using ABCDMallWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCDMallWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        // DbSet for all models
        public DbSet<Shop> Shops { get; set; }
        public DbSet<FoodCourt> FoodCourts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Ticket-Movie relationship with delete behavior
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MovieId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
