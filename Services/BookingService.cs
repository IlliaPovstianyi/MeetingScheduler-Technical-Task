namespace MeetingScheduler_Technical_Task.Services;
using MeetingScheduler_Technical_Task.Models;
using MeetingScheduler_Technical_Task.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BookingService : IBookingService
{
    private AppDbContext context;

    public BookingService(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<string?> GenerateBookingLink(User Owner)
    {
        BookingLink bookingLink = new BookingLink {
                Owner = Owner,
                OwnerId = Owner.Id,
                Token = Guid.NewGuid(),
                DateCreated = DateTime.Now
        };
        
        await context.BookingLinks.AddAsync(bookingLink);
        await context.SaveChangesAsync();

        Console.WriteLine("Added Link!");

        return $"book/{bookingLink.Token}";
    }

    public async Task<User?> GetLinkOwnerByToken(Guid Token)
    {
        BookingLink? link = await context.BookingLinks
        .Include(b => b.Owner).ThenInclude(o => o.Meetings)
        .Where(b => b.Token == Token)
        .FirstOrDefaultAsync();

        if(link == null)
        {
            return null; //TODO: Handle
        }
 
        return link.Owner;
    }

    public async Task MarkLinkExpired(Guid Token)
    {
        await context.BookingLinks
        .Where(b => b.Token == Token)
        .ExecuteUpdateAsync(b => b.SetProperty(x => x.IsExpired, true));
    }

    public async Task<bool> CheckLinkExpired(Guid Token)
    {
        //Here expired links can be removed if no logging/history features will be required

        return await context.BookingLinks
        .Where(b => b.Token == Token)
        .Select(b => b.IsExpired)
        .FirstOrDefaultAsync();
    }

    public async Task AssignMeetingToPerson(string OwnerGoogleId, Meeting newMeeting)
    {
        User user = await context.Users
            .Include(u => u.Meetings) 
            .FirstOrDefaultAsync(u => u.GoogleId == OwnerGoogleId);

        if (user == null)
            return; 

        user.Meetings ??= new List<Meeting>();
        user.Meetings.Add(newMeeting);

        await context.SaveChangesAsync();
    }
}