using System;
using System.Net;
using System.Text;
using System.Web;
using TelegramTest.GroupsHandler.Enums;

namespace TelegramTest.Helpers
{
    class Translate
    {
        private string _toLanguage;
        public Translate(Language to)
        {
            _toLanguage = to.ToString().ToLower().Substring(0, 2);
        }
        public string TranslateMessage(string originalMessage)
        {
            var result = InitializeTranslateGooglUrl(originalMessage);
            return TryGetTranslate(result);
        }
        private string InitializeTranslateGooglUrl(string originalMessage)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={_toLanguage}&dt=t&q={HttpUtility.UrlEncode(originalMessage)}";
            var webClient = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            return webClient.DownloadString(url);
        }
        private string TryGetTranslate(string result)
        {
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
}
