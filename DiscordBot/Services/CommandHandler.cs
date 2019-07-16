using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly IConfigurationRoot _config;
        private readonly IServiceProvider _provider;

        // DiscordSocketClient, CommandService, IConfigurationRoot, and IServiceProvider are injected automatically from the IServiceProvider
        public CommandHandler(
            DiscordSocketClient discord,
            CommandService commands,
            IConfigurationRoot config,
            IServiceProvider provider)
        {
            _discord = discord;
            _commands = commands;
            _config = config;
            _provider = provider;

            _discord.MessageReceived += OnMessageReceivedAsync;
        }

        private async Task OnMessageReceivedAsync(SocketMessage messageParam)
        {
            // Ensure the message is from a user/bot
            var message = messageParam as SocketUserMessage;     
            if (message == null) return;

            // Ignore self when checking commands
            if (message.Author.Id == _discord.CurrentUser.Id) return;     

            var context = new SocketCommandContext(_discord, message);     // Create the command context

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (message.HasStringPrefix(_config["CommandPrefix"], ref argPos) || 
                message.HasMentionPrefix(_discord.CurrentUser, ref argPos) ||
                message.Author.IsBot)
            {
                // Execute the command
                var result = await _commands.ExecuteAsync(context, argPos, _provider);     

                // If not successful, reply with the error.
                if (!result.IsSuccess)     
                    await context.Channel.SendMessageAsync(result.ToString());
            }
        }
    }
}
