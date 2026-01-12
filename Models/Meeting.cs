namespace MeetingScheduler_Technical_Task.Models;

public class Meeting
{
    public Guid Id { get; set; }
    public User? Guest { get; set;} 
    public Guid GuestID { get; set;} 
    public DateTime DateTime { get; set; }

}