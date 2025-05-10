using apiDeploy_Using_Docker.ModelClass;
using Microsoft.EntityFrameworkCore;

namespace apiDeploy_Using_Docker.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<student> students { get; set; }
    }
}
