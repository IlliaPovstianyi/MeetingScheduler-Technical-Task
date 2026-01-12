namespace MeetingScheduler_Technical_Task.Models;

public class BookingLink
{
    public Guid Id { get; set; }
    public Guid Token { get; set; }
    public User Owner { get; set; }
    public Guid OwnerId { get; set; }
    public DateTime? DateCreated { get; set; }
    public bool IsExpired { get; set; }
}