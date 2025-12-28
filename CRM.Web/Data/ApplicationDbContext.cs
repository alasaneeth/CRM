using CRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
    }
}
