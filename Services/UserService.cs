using MeetingScheduler_Technical_Task.Models;
using System.Security.Claims;

namespace MeetingScheduler_Technical_Task.Services;

public class UserService : IUserService
{
    public User? GetUserFromClaims(ClaimsPrincipal principal)
    {
        if (principal?.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        var email = principal.FindFirst(ClaimTypes.Email)?.Value
                    ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

        var givenName = principal.FindFirst(ClaimTypes.GivenName)?.Value
                        ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;

        var surname = principal.FindFirst(ClaimTypes.Surname)?.Value
                      ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;

        var name = principal.FindFirst(ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(email))
        {
            return null;
        }

        return new User
        {
            Email = email,
            FirstName = givenName ?? string.Empty,
            LastName = surname ?? string.Empty,
            ProfilePictureUrl = principal.FindFirst("picture")?.Value,
            AuthenticatedAt = DateTime.UtcNow
        };
    }
}