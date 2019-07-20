using System;
using System.Collections.Generic;

namespace DiscordBot.Models
{
    public class Guild
    {
        public int Id { get; set; }
        public ulong GuildId { get; set; }
        public User Owner { get; set; }
        public ulong OwnerId { get; set; }
        public List<GuildUser> GuildUsers { get; set; }

    }
}
