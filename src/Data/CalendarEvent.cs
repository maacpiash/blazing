namespace Blazing.Data;

public class CalendarEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required ApplicationUser User { get; set; }
    public string Title { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";

    public void UpdateFromDto(CalendarEventDto dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Title)) Title = dto.Title;
        if (!string.IsNullOrWhiteSpace(dto.Description)) Description = dto.Description;
        if (!string.IsNullOrWhiteSpace(dto.Location)) Location = dto.Location;
        Date = new DateTime(dto.Date, dto.Time);
    }
}

public class CalendarEventDto
{
    public Guid? Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Location { get; set; } = "";
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

    public CalendarEvent ToCalendarEvent(ApplicationUser user)
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
