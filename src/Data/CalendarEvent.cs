namespace Blazing.Data;

public class CalendarEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required ApplicationUser User { get; set; }
    public string Title { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
}
