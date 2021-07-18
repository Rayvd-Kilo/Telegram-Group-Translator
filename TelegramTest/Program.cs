using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using TelegramTest.Updates;

namespace TelegramTest
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("token");
        static UpdateHandler updateHandler = new UpdateHandler();

        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            bot.StartReceiving(new DefaultUpdateHandler(updateHandler.HandleUpdateAsync, updateHandler.HandleErrorAsync), cancellationToken);
            Console.ReadKey();
        }
    }
}
