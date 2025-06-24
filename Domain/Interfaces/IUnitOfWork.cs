namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository Users { get; }
        IMessageRepository Messages { get; }
        IConversationRepository Conversations { get; }

        Task<int> CompleteAsync();

    }
}
