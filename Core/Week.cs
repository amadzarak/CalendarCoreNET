using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core;
public class Day
{
    public DayOfWeek DayOfWeek { get; set; }
    public DateOnly Date { get; set; }
}

public enum WeekOfMonth
{
    First,
    Second,
    Third,
    Fourth,
    Last
}

public record struct DayOfWeek(string Name);
public class Week
{


    public DayOfWeek[] DaysOfWeek = 
        [
            new DayOfWeek("Sunday"),
            new DayOfWeek("Monday"),
            new DayOfWeek("Tuesday"),
            new DayOfWeek("Wednesday"),
            new DayOfWeek("Thursday"),
            new DayOfWeek("Friday"),
            new DayOfWeek("Saturday")
        ];

    public string GetDayOfWeekByOrdinal(int num)
    {
        if (num == 0 || num > 7)
            return string.Empty;
        return DaysOfWeek[num - 1].Name;
    }

    public int GetIndexByDayOfWeekString(string day)
    {
        return Array.FindIndex(DaysOfWeek, e => e.Name == day);
    }
    public int GetOrdinalByDayOfWeekString(string day)
    {
        return Array.FindIndex(DaysOfWeek, e => e.Name == day) + 1;
    }

    // For Use In Year

    //public int WeekOfYear { get; set; }
    //public int WeekOfMonth { get; set; }
    //public Day StartingSunday { get; set; }

    //public Day[] Days { get; set; }

}

public static class WeekExtensions
{
    public static int GetWeekOfYearByDate(this Week week, DateOnly date)
    {
        return 0;
    }
}

