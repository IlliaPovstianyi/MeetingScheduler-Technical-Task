namespace MeetingScheduler_Technical_Task.Models;

public class CalendarDay
    {
        public DateTime? Date { get; set; }
        public bool IsToday { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsBooked { get; set; }
        public bool IsHoliday { get; set; }
        public string? CustomClass { get; set; }
        public object? Data { get; set; } // For storing any additional data
    }