using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesForConversationAsync(Guid conversationId, int pageNumber, int pageSize);
        Task<Message?> GetMessageWithSenderAsync(Guid id);
    }
}
