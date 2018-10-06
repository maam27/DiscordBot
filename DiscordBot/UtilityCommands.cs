using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;

namespace DiscordBot
{
    [Group("utility")]
    [Aliases("util","u")]    
    class UtilityCommands
    {
        [Hidden]
        [RequireOwner]
        [Command("clearMessages")]
        [Aliases("clear","prune")]
        public async Task clearChat(CommandContext ctx, [Description("Amount of messages to clear")] int amount, DiscordUser member = null)
        {            
            IReadOnlyList<DiscordMessage> messages = await ctx.Channel.GetMessagesAsync(amount);
            List<DiscordMessage> msg = new List<DiscordMessage>();
            foreach (DiscordMessage m in messages) {
                if(m.Author == member || member == null) {
                    msg.Add(m);
                }                
            }           
            await ctx.Channel.DeleteMessagesAsync(msg);
        }       
    }
}
