namespace MeetingScheduler_Technical_Task.Models;

public class CalendarDay
{
    public DateTime? Date { get; set; }
    public bool IsToday { get; set; }
    public bool IsWeekend { get; set; }
    public bool IsBooked { get; set; }
    public bool IsHoliday { get; set; }
}