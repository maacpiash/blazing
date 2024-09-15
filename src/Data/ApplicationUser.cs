using Microsoft.AspNetCore.Identity;
using NanoidDotNet;
using static NanoidDotNet.Nanoid.Alphabets;

namespace Blazing.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();
}
