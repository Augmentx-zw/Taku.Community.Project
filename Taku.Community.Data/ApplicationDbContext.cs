using Microsoft.EntityFrameworkCore;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CommunityProject> CommunityProjects { get; set; }
        public DbSet<SubcribedCommunityProject> SubcribedCommunityProjects { get; set; }
    }
}
