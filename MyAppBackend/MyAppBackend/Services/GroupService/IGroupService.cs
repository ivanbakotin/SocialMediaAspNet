using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupService
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> SearchGroups(string param);
        Task<Group> GetGroupInfo(int id);
        Task<List<Group>> GetRecommendedGroups(int UserID);
        Task<IEnumerable<GroupViewModel>> GetUserGroups(int UserID);
        GroupViewModel CreateGroup(Group group, int UserID);
        PostViewModel CreateGroupPost(Post post, int UserID);
        Task UpdateGroupInfo(Group body, int GroupID, int UserID);
        Task DeleteGroup(int id, int UserID);
        Task<IEnumerable<User>> SearchGroupUsers(int id, string param);
        Task<IEnumerable<GroupMember>> GetGroupUsers(int id);
        Task<IEnumerable<PostViewModel>> GetGroupPosts(int GroupID, int UserID);
        Task RemoveGroupUser(int UserID, int GroupID);
    }
}
