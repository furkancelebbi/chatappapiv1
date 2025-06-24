using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Infrastructure.Persistence.Repositories;

public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<AppUser?> GetByEmailAsync(string email)
    {
        return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<AppUser?> GetByUsernameAsync(string username)
    {
        return await _context.AppUsers.FirstOrDefaultAsync(u => u.Username == username);
    }
}