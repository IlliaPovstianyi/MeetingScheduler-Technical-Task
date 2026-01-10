namespace MeetingScheduler_Technical_Task.Services;

public class CzechHolidays : IHolidayService
{
    public bool IsHoliday(DateTime dateTime)
    {
        // Fixed holidays
        var fixedHolidays = new (int Month, int Day)[]
        {
            (1, 1),   // Nový rok / Den obnovy samostatného českého státu
            (5, 1),   // Svátek práce
            (5, 8),   // Den vítězství
            (7, 5),   // Den slovanských věrozvěstů Cyrila a Metoděje
            (7, 6),   // Den upálení mistra Jana Husa
            (9, 28),  // Den české státnosti
            (10, 28), // Den vzniku samostatného československého státu
            (11, 17), // Den boje za svobodu a demokracii
            (12, 24), // Štědrý den
            (12, 25), // 1. svátek vánoční
            (12, 26)  // 2. svátek vánoční
        };

        if (fixedHolidays.Any(h => h.Month == dateTime.Month && h.Day == dateTime.Day))
            return true;

        // Movable holidays (Easter-based)
        var easterSunday = GetEasterSunday(dateTime.Year);
        var goodFriday = easterSunday.AddDays(-2);    // Velký pátek
        var easterMonday = easterSunday.AddDays(1);   // Velikonoční pondělí

        return dateTime.Date == goodFriday.Date || dateTime.Date == easterMonday.Date;
    }

    private DateTime GetEasterSunday(int year)
    {
        // Anonymous Gregorian algorithm
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int month = (h + l - 7 * m + 114) / 31;
        int day = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateTime(year, month, day);
    }
    
}