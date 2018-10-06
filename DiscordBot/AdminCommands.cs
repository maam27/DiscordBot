using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot
{
    [Group("admin")]
    class AdminCommands
    {
        [Hidden]
        [RequireOwner]
        [Command("setgame")]
        [Aliases("game")]
        public async Task playGame(CommandContext ctx, [RemainingText, Description("The game to be played")] string game) {
            CommandsNextModule cnm = Program.discord.GetCommandsNext();            
            await cnm.Client.UpdateStatusAsync(new DiscordGame(game));
        }

        [Hidden]     
        [RequireOwner]
        [Command("sudo")]
        [Description("Executes a command as another user.")]   
        public async Task Sudo(CommandContext ctx, [Description("Member to execute as.")] DiscordMember member, [RemainingText, Description("Command text to execute.")] string command)
        {
            // get the command service, we need this for
            // sudo purposes
            var cmds = ctx.CommandsNext;
  
            if (!command.StartsWith("."))
            {
                command = "." + command;
            }
            // and perform the sudo 
            await cmds.SudoAsync(member, ctx.Channel, command);
        }

        [Command("nick")]
        [Description("Gives someone a new nickname.")]
        [RequirePermissions(Permissions.ManageNicknames)]
        public async Task ChangeNickname(CommandContext ctx, [Description("Member to change the nickname for.")] DiscordMember member, [RemainingText, Description("The nickname to give to that user.")] string new_nickname)
        {            
            try
            {
                await member.ModifyAsync(new_nickname, reason: $"Changed by {ctx.User.Username} ({ctx.User.Id}).");
            }
            catch (Exception)
            {
                var emoji = DiscordEmoji.FromName(ctx.Client, ":no_entry_sign:");
                await ctx.RespondAsync(emoji+" Something went wrong.");
            }            
        }        

    }
}
