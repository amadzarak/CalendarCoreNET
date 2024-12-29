using System.Runtime.CompilerServices;

namespace Events;
// https://medium.com/tomorrowapp/the-complex-world-of-calendars-4a1bff1c4bfa
public class Event
{
    public int EventId { get; set; }
    public string EventTitle { get; set; }
    public string EventDescription { get; set; }
    public string Host { get; set; }
//    public int Price { get; set; } -- should be an extension, seperate table
}

public class EventParent
{
    public int Id { get; set; }
    
    public RecurrenceTemplate RecurrenceTemplate { get; set; } 
    public Event Event { get; set; }
    public EventException[] EventExceptions { get; set; }
    public EventCancellation[] EventCancellations { get; set; }
}

public class EventException
{
    public int Id { get; set; }
    public DateTime OriginalDate { get; set; }
    public DateTime Date { get; set; }
    public Event Parent { get; set; }
    public Event Event { get; set; }

}

public class EventCancellation
{
    public int Id { get; set; }
    public DateTime OriginalDate { get; set; }
}


// ------------------------------------------------
