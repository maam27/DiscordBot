using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;

namespace DiscordBot
{
    class Program
    {
        public static DiscordClient discord { get; set; }
        public static CommandsNextModule commands { get; set; }

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) {
            discord = new DiscordClient(new DiscordConfiguration {
                Token = "NDIxNzY1MjA5NzU4MjM2Njky.DpoxbA.gdPDqOHDKjBbo530XRm65KsCd_A",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "."                
            });
          
            commands.RegisterCommands<Commands>();
            commands.RegisterCommands<SettingsCommands>();
            commands.RegisterCommands<AdminCommands>();
            commands.RegisterCommands<UtilityCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }  
}

