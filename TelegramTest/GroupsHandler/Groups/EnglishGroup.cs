using Telegram.Bot.Types;
using TelegramTest.Helpers;

namespace TelegramTest.GroupsHandler.Groups
{
    class EnglishGroup :Group
    {
        public EnglishGroup(long chatId)
        {
            _chatId = chatId;
            _language = Enums.Language.English;
        }

        public override string SetGroupMessage(Update update)
        {
            var messageText = $"User '{"@" + update.Message.From.Username}' from chat '{update.Message.Chat.Title}' typed:\n{new Translate(_language).TranslateMessage(update.Message.Text)}";
            return messageText;
        }
    }
}
