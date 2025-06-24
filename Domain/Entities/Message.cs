namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public required string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public Guid SenderId { get; set; }
        public Guid ConversationId { get; set; }

        public AppUser Sender { get; set; } = null!;
        public Conversation Conversation { get; set; } = null!;
    }
}
