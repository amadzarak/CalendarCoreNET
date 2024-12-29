namespace Core;


public record struct Month(string Name);
public class Calendar
{

    public Month[] Months = 
        [
            new Month("January"),
            new Month("February"), 
            new Month("March"), 
            new Month("April"), 
            new Month("May"), 
            new Month("June"), 
            new Month("July"), 
            new Month("August"),
            new Month("September"), 
            new Month("October"), 
            new Month("November"), 
            new Month("December")
        ];

    public int[] Days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    public int? Year { get; set; }

    public string GetMonthByOrdinal(int num)
    {
        if (num == 0 || num > 12)
            return string.Empty;

        return Months[num - 1].Name;
    }

    public int GetIndexByMonthString(string month)
    {
        return Array.FindIndex(Months, e => e.Name == month);
    }
    public int GetOrdinalByMonthString(string month)
    {
        return Array.FindIndex(Months, e => e.Name == month) + 1;
    }

    public int GetLengthOfMonthByString(string month)
    {
        if (month == "February")
        {
            if (Year == null) { return 0; }
            return GetIsLeapYear() ? 29 : 28;
        }
        var index = GetIndexByMonthString(month);
        return Days[index];
    }

    public bool GetIsLeapYear()
    {
        if (Year == null)
        {
            return false;
        }

        return CalendarHelpers.IsLeap(Year ?? 0);
    }
}
