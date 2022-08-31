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
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);   

        }

       
    }
}
