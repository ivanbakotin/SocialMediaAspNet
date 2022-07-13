using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.GroupRepositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<User>> SearchGroupUsers(int GroupID, string param);
        Task<IEnumerable<PostViewModel>> GetGroupPosts(int GroupID, int UserID);
        Task<IEnumerable<GroupViewModel>> GetUserGroups(int UserID);
    }
}
