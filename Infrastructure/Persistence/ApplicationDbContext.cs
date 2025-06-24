using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserConversation>()
                .HasKey(uc => new { uc.AppUserId, uc.ConversationId });

            modelBuilder.Entity<UserConversation>()
        .HasOne(uc => uc.AppUser)
        .WithMany(u => u.UserConversations)
        .HasForeignKey(uc => uc.AppUserId);

            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.Conversation)
                .WithMany(c => c.UserConversations)
                .HasForeignKey(uc => uc.ConversationId);


            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
