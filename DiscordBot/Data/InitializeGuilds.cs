using System;
using System.Collections.Generic;
using System.Linq;
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
            var alreadyExists = _context.Guilds.FirstOrDefault(g => g.GuildId == guildParam.Id);

            if (alreadyExists != null)
            {
                return;
            }

            var guild = new Guild
            {
                DateCreated = guildParam.CreatedAt,
                GuildId = guildParam.Id,
                GuildName = guildParam.Name,
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
