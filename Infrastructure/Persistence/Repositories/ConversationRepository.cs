using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

namespace ChatAPI.Infrastructure.Persistence.Repositories;

public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
{
    public ConversationRepository(ApplicationDbContext context) : base(context)
    {
    }


    public Task<IEnumerable<Conversation>> GetConversationsForUserAsync(Guid userId)
    {

        throw new NotImplementedException();
    }
}