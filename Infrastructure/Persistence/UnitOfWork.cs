using ChatAPI.Infrastructure.Persistence.Repositories;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories; // EKLENMESİ GEREKEN SATIR BURASI!

namespace ChatAPI.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IAppUserRepository Users { get; private set; }
    public IMessageRepository Messages { get; private set; }
    public IConversationRepository Conversations { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        // Tüm repository'lerin burada oluşturulduğundan emin olalım.
        Users = new AppUserRepository(_context);
        Messages = new MessageRepository(_context);
        Conversations = new ConversationRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}