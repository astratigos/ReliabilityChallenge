using Microsoft.EntityFrameworkCore;
using ReliabilityChallenge.Models;
using System.IO;
using System.Reflection;

namespace ReliabilityChallenge.Services
{
    public class ConsoleAppContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\ConsoleAppDB.db");
    }
}
