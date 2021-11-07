using System;
using Microsoft.EntityFrameworkCore.Design;

namespace MZCovidBot.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            return new(Environment.GetEnvironmentVariable("POSTGRES_STRING") ??
                       "Server=localhost;Database=MZCovidBot;Uid=mzcovid;Pwd=1234;");
        }
    }
}