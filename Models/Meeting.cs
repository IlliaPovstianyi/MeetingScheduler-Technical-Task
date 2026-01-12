namespace MeetingScheduler_Technical_Task.Models;

public class Meeting
{
    public Guid Id { get; set; }
    public string? GuestFirstName { get; set; }
    public string? GuestLastName { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DateTime CreatedAt { get; set; }
    
    
}