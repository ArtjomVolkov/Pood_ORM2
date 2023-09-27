using Microsoft.EntityFrameworkCore;
using Pood.Models;

namespace Pood.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Poodi> Pood { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
