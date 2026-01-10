using MeetingScheduler_Technical_Task.Models;
using System.Security.Claims;

namespace MeetingScheduler_Technical_Task.Services;

public interface IUserService
{
    /// Get user data from authentication claims
    Task<User?> GetUserFromClaims(ClaimsPrincipal principal);
}