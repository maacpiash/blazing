namespace Blazing.Data;

public class MusicFile
{
    public Guid Id { get; set; }

    public required ApplicationUser User { get; set; }
    public string Title { get; set; } = "";
    public string S3Url { get; set; } = "";

    public DateTime Expires { get; set; }
}
