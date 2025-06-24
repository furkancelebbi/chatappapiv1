using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser?> GetByUsernameAsync(string username);
        Task<AppUser?> GetByEmailAsync(string email);
    }
}
