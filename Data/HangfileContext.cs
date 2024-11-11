using Hangfire_EmailNotification.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_EmailNotification.Context;


public class HangfileContext : DbContext
{
    public HangfileContext(DbContextOptions<HangfileContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<UserModel> CustomerInformation { get; set; }
    
}