using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using TelegramTest.GroupsHandler.Groups;

namespace TelegramTest.Updates
{
    class UpdateHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                if (update.Message.Text != null && update.Message.Text.Length < 600)
                {
                    var groups = GetGroupsToReplyMessage(CheckChatID(update));
                    foreach (var group in groups)
                    {
                        var messageText = group.SetGroupMessage(update);
                        await botClient.SendTextMessageAsync(group.ChatId, messageText);
                    }
                }
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(52, apiRequestException.ToString());
            }
        }
        private Group CheckChatID(Update update)
        {
            var idSet = new HashSet<Group>(GroupsHandler.GroupsHandler.Groups);
            var result = idSet.First(u => u.ChatId == update.Message.Chat.Id);
            return result;
        }
        private Group[] GetGroupsToReplyMessage(Group ignoreGroup)
        {
            var groupSet = new HashSet<Group>(GroupsHandler.GroupsHandler.Groups);
            var groupsToReply = groupSet.Where(u => u.Language != ignoreGroup.Language);
            return groupsToReply.ToArray();
        }
    }
}
