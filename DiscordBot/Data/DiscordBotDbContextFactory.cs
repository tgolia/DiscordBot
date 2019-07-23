using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiscordBot.Data
{
    public class DiscordBotDbContextFactory : IDesignTimeDbContextFactory<DiscordBotDbContext>
    {
        public DiscordBotDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<DiscordBotDbContext>();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = DiscordBotData; Trusted_Connection = True;";

            builder.UseSqlServer(connectionString);

            return new DiscordBotDbContext(builder.Options);
        }
    }
}
