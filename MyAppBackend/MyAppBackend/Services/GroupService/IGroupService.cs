using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> SearchGroups(string param);
        dynamic SearchGroupUsers(int id, string param);
        Task<List<GroupMember>> GetGroupUsers(int id);
        Task<List<Post>> GetGroupPosts(int id);
        Task<Group> GetGroupInfo(int id);
        Task UpdateGroupInfo(Group body, int GroupID, int UserID);
        Task DeleteGroup(int id, int UserID);
        Task RemoveGroupUser(int UserID, int GroupID);
        Task<Group> CreateGroup(Group group, int UserID);
        dynamic GetUserGroups(int UserID);
        void GetRecommendedGroups(int UserID);
    }
}
