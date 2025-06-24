using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Message>> GetMessagesForConversationAsync(Guid conversationId, int pageNumber, int pageSize)
    {

        return await _context.Messages
            .Where(m => m.ConversationId == conversationId)
            .Include(m => m.Sender)
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }


    public async Task<Message?> GetMessageWithSenderAsync(Guid id)
    {
        return await _context.Messages
            .Include(m => m.Sender)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}