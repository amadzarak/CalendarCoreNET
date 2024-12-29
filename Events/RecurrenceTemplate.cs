using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://www.hl7.org/fhir/appointment.html
namespace Events;

public enum RecurrenceType
{
    Once,
    Daily,
    Weekly,
    Monthly,
    Yearly
}

public class WeeklyTemplate : Week
{
    public bool[] WeeklyBools { get; set; } = 
        [
            false, 
            false, 
            false, 
            false, 
            false, 
            false, 
            false
        ];

    public bool GetWeeklyBoolValue_FromString(string dayOfWeek)
    {
        int index = Array.IndexOf(DaysOfWeek, dayOfWeek);
        return WeeklyBools[index];
    }

    public bool GetWeeklyBoolValue_FromIndex(int index)
    {
        return WeeklyBools[index];
    }

    public bool GetWeeklyBoolValue_FromOrdinal(int index)
    {
        return WeeklyBools[index - 1];
    }

    public void SetWeeklyBools(bool[] weeklyBools)
    {
        WeeklyBools = weeklyBools;
    }

    public void SetWeeklyBools(string[] days)
    {
        for (int i = 0; i < days.Count(); i++)
        {
            var idx = GetIndexByDayOfWeekString(days[i]);
            WeeklyBools[idx] = true;
        }
    }
}


public class MonthlyTemplate
{
    public int DayOfMonth { get; set; }
    public Core.DayOfWeek[] DaysOfWeek { get; set; }
    public int MonthInterval { get; set; }
    public WeekOfMonth[] WeekOfMonth { get; set; }
//    public int[] NthWeekOfMonth { get; set; }
}

public class YearlyTemplate 
{
    public int YearInterval { get; set; }
}

public class RecurrenceTemplate
{
    public string Rule { get; set; }
    public RecurrenceType RecurrenceType { get; set; } = RecurrenceType.Once;

    public DateOnly LastOccurenceDate { get; set; }
    public int OccurenceCount { get; set; }
    public DateOnly[] OccurenceDates { get; set; }

    public WeeklyTemplate WeeklyTemplate { get; set; }
    
    public DateOnly[] ExcludingDate { get; set; }
    public int[] ExcludingRecurrenceId { get; set; }
}



public static class RecurrenceTemplateExtensions
{
    public static string GenerateRRuleString(this RecurrenceTemplate template)
    {
        return string.Empty;
    }

    public static RecurrenceTemplate ParseRRuleString(this string ruleString)
    {
        return new RecurrenceTemplate { Rule = ruleString };
    }



}
