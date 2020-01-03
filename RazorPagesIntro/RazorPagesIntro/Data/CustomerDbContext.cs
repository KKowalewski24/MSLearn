using Microsoft.EntityFrameworkCore;
using RazorPagesIntro.Models;

namespace RazorPagesIntro.Data
{
    public class CustomerDbContext : DbContext
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        #region Properties

        public DbSet<Customer> Customers { get; set; }

        #endregion
        /*------------------------ METHODS REGION ------------------------*/
        #region Methods

        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion
    }
}