namespace MeetingScheduler_Technical_Task.Models;

public class CalendarDay
{
    public DateTime? Date { get; set; }
    public bool IsToday { get; set; }
    public bool IsWeekend { get; set; }
    public bool HasMeeting { get; set; }
    public bool IsFullyBooked { get; set; }
    public bool IsHoliday { get; set; }
    public bool IsPast { get; set; }
    public bool IsTooFarAhead { get; set; }
    public int BookingCount { get; set; }
    public bool IsAvailable => Date.HasValue && 
                                    !IsPast &&
                                    !IsTooFarAhead &&
                                    !IsWeekend && 
                                    !IsHoliday && 
                                    !IsFullyBooked;
}