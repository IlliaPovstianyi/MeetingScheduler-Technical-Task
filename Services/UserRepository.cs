namespace MeetingScheduler_Technical_Task.Services;
using MeetingScheduler_Technical_Task.Models;
using Microsoft.EntityFrameworkCore;
using MeetingScheduler_Technical_Task.Data;

public class UserRepository : IUserRepository
{
    private AppDbContext context;

    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<User?> FindByGoogleIdAsync(string googleId)
    {
        return await context.Users
        .Where(u => u.GoogleId == googleId)
        .FirstOrDefaultAsync();
    }
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }
    public async Task<User> AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }
}