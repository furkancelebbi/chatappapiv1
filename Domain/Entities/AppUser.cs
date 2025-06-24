namespace Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];


        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<UserConversation> UserConversations { get; set; } = new List<UserConversation>();
    }
}
