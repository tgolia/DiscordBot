using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class StartupService
    {
        private readonly IServiceProvider _provider;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly IConfigurationRoot _config;

        public StartupService(
            IServiceProvider provider,
            DiscordSocketClient discord,
            CommandService commands,
            IConfigurationRoot config)
        {
            _provider = provider;
            _config = config;
            _discord = discord;
            _commands = commands;
        }

        public async Task StartAsync()
        {
            string discordToken = _config["BotToken"];

            if (string.IsNullOrWhiteSpace(discordToken))
            {
                throw new Exception("Please enter your bot's token into the `_configuration.json` file found in the applications root directory.");
            }

            // Login to discord
            await _discord.LoginAsync(TokenType.Bot, discordToken);

            // Connect to the websocket
            await _discord.StartAsync();

            // Load commands and modules into the command service
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);     
        }
    }
}
