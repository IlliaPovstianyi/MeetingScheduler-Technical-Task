namespace MeetingScheduler_Technical_Task.Services;
using MeetingScheduler_Technical_Task.Models;
using MeetingScheduler_Technical_Task.Data;
using System.Threading.Tasks;

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
}