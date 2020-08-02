using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Models;

namespace RazorPagesIntro.Data {

    public class AppDbContext : DbContext {

        /*----------------------- PROPERTIES REGION ----------------------*/
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public AppDbContext(DbContextOptions options)
            : base(options) {
        }

    }

}
