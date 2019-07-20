using System;
using System.Collections.Generic;

namespace DiscordBot.Models
{
    public class Guild
    {
        public int Id { get; set; }
        public long GuildId { get; set; }
        public string Owner { get; set; }
        public long OwnerId { get; set; }
        public ushort DiscriminatorValue { get; set; }
        public List<GuildUser> GuildUsers { get; set; }

    }
}
