using MeetingScheduler_Technical_Task.Models;
public interface IUserRepository
{
    Task<User?> FindByGoogleIdAsync(string googleId);
    Task<User?> GetByIdAsync(Guid id);
    Task<User> AddAsync(User user);
}