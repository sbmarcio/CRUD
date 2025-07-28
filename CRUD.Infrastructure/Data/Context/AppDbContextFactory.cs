using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CRUD.Infrastructure.Data.Context;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CRUD.API"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder
            .UseSqlServer("Server=localhost,1433;Database=DBCRUD;User ID=sa;Password=1a2b3c4d!@#$")
            .LogTo(Console.WriteLine, LogLevel.Information);

        return new AppDbContext(optionsBuilder.Options);
    }
}
