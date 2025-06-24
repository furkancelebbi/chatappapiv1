namespace Application.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public Guid SenderId { get; set; }
        public required string SenderUsername { get; set; }
        public Guid ConversationId { get; set; }
    }
}
