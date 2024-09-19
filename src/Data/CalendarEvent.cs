namespace Blazing.Data;

public class CalendarEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required ApplicationUser User { get; set; }
    public string Title { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";

    internal void UpdateFromDto(CalendarEventDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        Location = dto.Location;
        Date = new DateTime(dto.Date, dto.Time);
    }
}

internal class CalendarEventDto
{
    internal Guid? Id { get; set; }
    internal string Title { get; set; } = "";
    internal string Description { get; set; } = "";
    internal string Location { get; set; } = "";
    internal DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    internal TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

    internal CalendarEvent ToCalendarEvent(ApplicationUser user)
    {
        var calendarEvent = new CalendarEvent()
        {
            User = user
        };

        if (Id is not null && Id != Guid.Empty) calendarEvent.Id = (Guid)Id;
        calendarEvent.Title = Title;
        calendarEvent.Description = Description;
        calendarEvent.Location = Location;
        calendarEvent.Date = new DateTime(Date, Time);
        return calendarEvent;
    }
}
