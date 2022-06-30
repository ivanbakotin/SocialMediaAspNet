using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyAppBackend.Services.GroupService
{
    public interface IGroupService
    {
        dynamic SearchGroups(string param);
        dynamic SearchGroupUsers(int id, string param);
        dynamic GetGroupUsers(int id);
        dynamic GetGroupPosts(int id);
        dynamic GetGroupInfo(int id);
        void UpdateGroupInfo(Group body, int GroupID);
        void DeleteGroup(int id);
        void RemoveGroupUser(int UserID, int GroupID);
        dynamic CreateGroup(Group group, int UserID);
        dynamic GetUserGroups(int UserID);
        void GetRecommendedGroups(int UserID);
    }
}
