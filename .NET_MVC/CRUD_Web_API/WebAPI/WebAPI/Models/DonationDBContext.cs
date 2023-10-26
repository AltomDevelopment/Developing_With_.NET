using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAPI.Models
{
    public class DonationDBContext : DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Dcandidate> DCandidates { get; set; }
    }
}
