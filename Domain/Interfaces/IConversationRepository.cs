using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConversationRepository : IGenericRepository<Conversation>
    {
        Task<IEnumerable<Conversation>> GetConversationsForUserAsync(Guid userId);
    }
}
