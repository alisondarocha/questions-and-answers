using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Q.A.__social_network.Models;

namespace Q.A.__social_network.Data
{
    public class Social_NetworkContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public Social_NetworkContext(DbContextOptions<Social_NetworkContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public void Configure(EntityTypeBuilder<QuestionModel> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Questions).HasForeignKey(x => x.User);
        }
    }
} 