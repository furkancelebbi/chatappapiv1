namespace Domain.Entities
{
    public class Conversation : BaseEntity
    {
        public string? Name { get; set; }


        public ICollection<Message> Messages { get; set; } = new List<Message>();


        public ICollection<UserConversation> UserConversations { get; set; } = new List<UserConversation>();
    }
}
