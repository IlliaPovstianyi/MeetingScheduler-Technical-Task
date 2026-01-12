using MeetingScheduler_Technical_Task.Models;
public interface IBookingService
{
    Task<string?> GenerateBookingLink(User Owner);
}