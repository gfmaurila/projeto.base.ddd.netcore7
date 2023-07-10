using Data.SQLServer.Mappings;
using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer.Config;
public class SQLServerContext : DbContext
{
    public SQLServerContext()
    { }

    public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
    { }

    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfigurations());
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseLoggerFactory(_loggerFactory);
    //    base.OnConfiguring(optionsBuilder);
    //}

    //public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory = new LoggerFactory(new[] {
    //    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    //});
}
