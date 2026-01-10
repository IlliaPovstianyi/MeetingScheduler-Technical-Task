using MeetingScheduler_Technical_Task.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeetingScheduler_Technical_Task.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<User?> GetUserFromClaims(ClaimsPrincipal principal)
    {
        if (principal?.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        var googleId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        if (googleId == null)
        {
            return null;
        }

        if(await userRepository.FindByGoogleIdAsync(googleId) != null)
        {
            Console.WriteLine("USER RESTORED FROM DB");
            return await userRepository.FindByGoogleIdAsync(googleId);
        } else
        {
            var email = principal.FindFirst(ClaimTypes.Email)?.Value
                    ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var givenName = principal.FindFirst(ClaimTypes.GivenName)?.Value
                            ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;
            var surname = principal.FindFirst(ClaimTypes.Surname)?.Value
                        ?? principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(googleId))
            {
                return null;
            }
            
            User user = new User
            {
                Email = email,
                GoogleId = googleId,
                FirstName = givenName ?? string.Empty,
                LastName = surname ?? string.Empty,
                ProfilePictureUrl = principal.FindFirst("picture")?.Value,
                AuthenticatedAt = DateTime.UtcNow
            };

            await userRepository.AddAsync(user);
            Console.WriteLine("ADDED TO DB");
            return user;
        }

        
    }
}