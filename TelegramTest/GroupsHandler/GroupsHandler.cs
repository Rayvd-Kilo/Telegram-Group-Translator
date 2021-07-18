using System.Collections.Generic;
using TelegramTest.GroupsHandler.Groups;

namespace TelegramTest.GroupsHandler
{
    static class GroupsHandler
    {
        public static IList<Group> Groups => SetGroups();
        private static IList<Group> SetGroups()
        {
            var groupsList = new List<Group>();
            groupsList.Add(new EnglishGroup(000));
            groupsList.Add(new RussianGroup(001));
            groupsList.Add(new SpanishGroup(002));
            return groupsList;
        }
    }
}
