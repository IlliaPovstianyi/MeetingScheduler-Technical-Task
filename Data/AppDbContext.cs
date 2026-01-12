using Microsoft.EntityFrameworkCore;
using MeetingScheduler_Technical_Task.Models;

namespace MeetingScheduler_Technical_Task.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users
    {
        get { return Set<User>(); }
    }

    public DbSet<Meeting> Meetings
    {
        get { return Set<Meeting>(); }
    }

    public DbSet<BookingLink> BookingLinks
    {
        get { return Set<BookingLink>(); }
    }
}