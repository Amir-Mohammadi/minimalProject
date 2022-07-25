using Microsoft.EntityFrameworkCore;
using minimalProject.Core.Domains.User;
using System.Reflection;

namespace minimalProject.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = this.GetType().Namespace;

        }

        public DbSet<User> Users { get; set; }
        public DbSet<IpDetect> ipDetects { get; set; }
    }
}
