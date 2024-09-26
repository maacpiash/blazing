using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blazing.Data;

namespace Blazing.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>()
            .HasMany(user => user.CalendarEvents)
            .WithOne(calEvent => calEvent.User);
        builder.Entity<ApplicationUser>()
            .HasMany(user => user.MusicFiles)
            .WithOne(musicFile => musicFile.User);
    }

    public DbSet<CalendarEvent> CalendarEvents { get; set; } = default!;
    public DbSet<MusicFile> MusicFiles { get; set; } = default!;
}
