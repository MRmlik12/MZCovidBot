using System;
using Microsoft.EntityFrameworkCore.Design;

namespace MZCovidBot.Database
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
            => new (Environment.GetEnvironmentVariable("POSTGRES_STRING") ?? "Server=localhost;Database=lern;Uid=test;Pwd=123;");
    }
}