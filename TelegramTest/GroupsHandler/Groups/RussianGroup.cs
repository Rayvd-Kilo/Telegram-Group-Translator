using Telegram.Bot.Types;
using TelegramTest.Helpers;

namespace TelegramTest.GroupsHandler.Groups
{
    class RussianGroup : Group
    {
        public RussianGroup(long chatId)
        {
            _chatId = chatId;
            _language = Enums.Language.Russian;
        }
        public override string SetGroupMessage(Update update)
        {
            var messageText = $"Пользователь '{"@" + update.Message.From.Username}' из чата '{update.Message.Chat.Title}' Написал:\n{new Translate(_language).TranslateMessage(update.Message.Text)}";
            return messageText;
        }
    }
}
