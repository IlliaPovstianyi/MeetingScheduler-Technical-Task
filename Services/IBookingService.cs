using MeetingScheduler_Technical_Task.Models;
public interface IBookingService
{
    Task<string?> GenerateBookingLink(User Owner);
    Task<User?> GetLinkOwnerByToken(Guid Token);
    Task MarkLinkExpired(Guid Token);
    Task AssignMeetingToPerson(string OwnerId, Meeting meeting);
}