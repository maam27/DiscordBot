using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus;
using System;

namespace DiscordBot
{
    class Commands
    {
        [Command("ping")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync(Program.discord.Ping+"ms");
        }

        [Command("dice")]
        public async Task dice(CommandContext ctx, [Description("Dice to be thrown")] string dice,[Description("Number of times to throw the dice")] int timesToThrow = 1) {
            if (dice.ToLower().StartsWith("d")) {
                dice = dice.Substring(1);
            }
            int.TryParse(dice, out int diceValue);
            if (diceValue == 0) {
                return;
            }
            for (int i = 0; i < timesToThrow; i++)
            {
                await ctx.RespondAsync(new Random().Next(diceValue + 1).ToString());
            }
        }

        [Hidden]
        [Command("myavatar")]
        public async Task me(CommandContext ctx)
        {
            await ctx.RespondAsync(ctx.User.AvatarUrl);
        }             
    }
}
