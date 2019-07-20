using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot.Models;

namespace DiscordBot.Data
{
    public class InitializeGuilds : IInitializeGuilds
    {
        private DiscordBotDbContext _context;

        public InitializeGuilds(DiscordBotDbContext context)
        {
            _context = context;
        }

        public async Task AddNewGuild(SocketGuild guildParam)
        {
            var guild = new Guild
            {
                GuildId = guildParam.Id,
                OwnerId = guildParam.OwnerId,
                GuildUsers = new List<GuildUser>()
            };

            await _context.Guilds.AddAsync(guild);

            await _context.SaveChangesAsync();

        }

        public Task SaveGuildUsers(SocketGuild guild)
        {
            throw new NotImplementedException();
        }
    }
}
