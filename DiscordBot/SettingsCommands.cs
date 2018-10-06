using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    [Group("settings")]
    [Description("setting commands")]
    [RequirePermissions(Permissions.ManageGuild)]
    class SettingsCommands
    {    
        // this command will be only executable by the bot's owner
        [Command("setprefix")]
        [Aliases("prefix")]
        [RequireOwner]
        [Hidden]
        public async Task Setprefix(CommandContext ctx, [RemainingText, Description("string to use as the new prefix.")] string prefix)
        {
            if (prefix.Length > 0)
            {
                ctx.Client.UseCommandsNext(new CommandsNextConfiguration
                {
                    StringPrefix = prefix
                });
                await ctx.RespondAsync($"new prefix " + prefix);
            }
            await ctx.RespondAsync($"The prefix is set to: ");            
        }

        //[Command("nick"), Description("Gives someone a new nickname."), RequirePermissions(Permissions.ManageNicknames)]
        //public async Task ChangeNickname(CommandContext ctx, [Description("Member to change the nickname for.")] DiscordMember member, [RemainingText, Description("The nickname to give to that user.")] string new_nickname)
        //{
        //    // let's trigger a typing indicator to let
        //    // users know we're working
        //    await ctx.TriggerTypingAsync();

        //    try
        //    {
        //        // let's change the nickname, and tell the 
        //        // audit logs who did it.
        //        await member.ModifyAsync(new_nickname, reason: $"Changed by {ctx.User.Username} ({ctx.User.Id}).");

        //        // let's make a simple response.
        //        var emoji = DiscordEmoji.FromName(ctx.Client, ":+1:");

        //        // and respond with it.
        //        await ctx.RespondAsync(emoji);
        //    }
        //    catch (Exception)
        //    {
        //        // oh no, something failed, let the invoker now
        //        var emoji = DiscordEmoji.FromName(ctx.Client, ":-1:");
        //        await ctx.RespondAsync(emoji);
        //    }
        //}
    }
}