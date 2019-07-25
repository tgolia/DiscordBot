using System;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordBot.Data
{
    public interface IInitializeGuilds
    {
        Task AddNewGuild(SocketGuild guild);

        Task SaveGuildUsers(SocketGuild guild);
    }
}
