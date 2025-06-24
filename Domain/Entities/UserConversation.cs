namespace Domain.Entities
{
    public class UserConversation
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;
    }
}