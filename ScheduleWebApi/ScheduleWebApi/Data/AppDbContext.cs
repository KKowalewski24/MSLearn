using Microsoft.EntityFrameworkCore;
using ScheduleWebApi.Models;

namespace ScheduleWebApi.Data
{
    public class AppDbContext : DbContext
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        public DbSet<ScheduleItem> ScheduleItems { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}