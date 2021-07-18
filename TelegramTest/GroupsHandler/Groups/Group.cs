using Telegram.Bot.Types;
using TelegramTest.GroupsHandler.Enums;

namespace TelegramTest.GroupsHandler.Groups
{
    abstract class Group
    {
        protected long _chatId;
        protected Language _language;
        public long ChatId { get { return _chatId; } }
        public Language Language { get { return _language; } }

        public abstract string SetGroupMessage(Update update);
    }
}
