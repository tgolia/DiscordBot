using Discord.Commands;
using DiscordBot.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        private IInitializeGuilds _guildRepo;

        public AdminModule(IInitializeGuilds guildRepo)
        {
            _guildRepo = guildRepo;
        }

        [Command("Init")]
        public Task InitializeGuildAsync()
        {
            var guild = Context.Guild;
            _guildRepo.AddNewGuild(guild);
            _guildRepo.SaveGuildUsers(guild);
            return Task.FromResult(true);
        }
    }
}
