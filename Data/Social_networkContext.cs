using Microsoft.EntityFrameworkCore;
using Q.A.__social_network.Models;
using System.Linq;

namespace Q.A.__social_network.Data
{
    public class Social_NetworkContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public Social_NetworkContext(DbContextOptions<Social_NetworkContext> options) : base(options)
        {
        }

    }
}