using Telegram.Bot.Types;
using TelegramTest.Helpers;

namespace TelegramTest.GroupsHandler.Groups
{
    class SpanishGroup : Group
    {
        public SpanishGroup(long chatId)
        {
            _chatId = chatId;
            _language = Enums.Language.Espaniol;
        }
        public override string SetGroupMessage(Update update)
        {
            var messageText = $"El usuario '{"@"+update.Message.From.Username}' del chat '{update.Message.Chat.Title}' escribió:\n{new Translate(_language).TranslateMessage(update.Message.Text)}";
            return messageText;
        }
    }
}
