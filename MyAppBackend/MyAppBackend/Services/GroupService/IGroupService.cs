using MyAppBackend.Models;

namespace MyAppBackend.Services.GroupService
{
    public interface IGroupService
    {
        dynamic SearchGroups(string param);
        dynamic SearchGroupUsers(int id, string param);
        dynamic GetGroupUsers(int id);
        dynamic GetGroupPosts(int id);
        dynamic GetGroupInfo(int id);
        dynamic UpdateGroupInfo(int id);
        dynamic DeleteGroup(int id);
        dynamic RemoveGroupUser(int id);
        Group CreateGroup(Group group, int UserID);
        dynamic GetUserGroups(int UserID);
        void GetRecommendedGroups(int UserID);
    }
}
